using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class ClientLogHandler:IPacketHandler
    {
        private IMainView gui;
        private int channel;
        private string imei;

        public ClientLogHandler(int channel, string imei, IMainView gui)
        {
            this.gui = gui;
            this.channel = channel;
            this.imei = imei;
        }

        public void Receive(IPacket p, string imeiId)
        {
            
        }

        public void HandlePacket(IPacket p, string tempIMEI, Server c)
        {
            c.ChannelHandlerMap[imei].GetStorage(channel).Reset();
            var packet = (LogPacket)p;
            if (packet.Type == 0) 
                gui.Log.ClientLogTxt(imei, packet.Date, packet.Message);
            else 
                gui.Log.ClientErrLogTxt(imei, packet.Date, packet.Message);
        }
    }
}
