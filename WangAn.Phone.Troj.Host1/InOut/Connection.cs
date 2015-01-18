using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace InOut
{
    public class Connection
    {

        //Simulation Virtual IP 10.0.2.2
        //private int port = 13550;

        private Socket s;
        private readonly String ip;
        private readonly int port;
        private Stream outStream;
        private Stream inStream;
        private Stream readInstruction;
        private Mux m;
        private Demux dem;
        private readonly IController controler;
        private Receiver receive;

        public Connection(String ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public Connection(String ip, int port, IController ctrl)
        {
            this.ip = ip;
            this.port = port;
            controler = ctrl;
        }

        public bool Connect()
        {
            try
            {

                s = new Socket(SocketType.Stream, ProtocolType.Tcp);
                s.Connect(IPAddress.Parse(ip), port);
                outStream = new NetworkStream(s);
                inStream = new NetworkStream(s);
                m = new Mux(outStream);
                dem = new Demux(controler, "moi");
                receive = new Receiver(s);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        public bool Reconnect()
        {
            return Connect();
        }

        public bool Accept(Socket ss)
        {
            try
            {
                s = ss.Accept();
                inStream = new NetworkStream(ss);
                outStream = inStream;
                m = new Mux(outStream);
                return true;

            }
            catch (IOException)
            {
                return false;
            }
        }

        public Stream GetInstruction()
        {
            readInstruction = receive.Read();
            readInstruction.Position = 0;
            if (dem.Receive(readInstruction))
                readInstruction.Position = 0;
            else
                readInstruction.Close();

            return readInstruction;
        }

        public void SendData(int chan, byte[] packet)
        {
            m.Send(chan, packet);
        }

        public void Stop()
        {
            try
            {
                s.Close();
            }
            catch (IOException)
            {

            }
        }
    }
}
