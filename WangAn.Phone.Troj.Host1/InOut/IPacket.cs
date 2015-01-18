namespace InOut
{
    public interface IPacket
    {
        byte[] Build();
        void Parse(byte[] packat);
    }

}
