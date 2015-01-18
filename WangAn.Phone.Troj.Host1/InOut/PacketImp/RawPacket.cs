namespace InOut.PacketImp
{
    public class RawPacket:IPacket
    {
        public byte[] Data { get; set; }

        public RawPacket()
        {
            // Nothing
        }

        public RawPacket(byte[] data)
        {
            Data = data;
        }

        public byte[]  Build()
        {
            return Data;
        }

        public void Parse(byte[] packet)
        {
            Data = packet;
        }
    }
}
