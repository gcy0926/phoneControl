using InOut.PacketImp;

namespace InOut
{
    public interface IController
    {
        void Storage(TransportPacket tp, string i);
    }
}
