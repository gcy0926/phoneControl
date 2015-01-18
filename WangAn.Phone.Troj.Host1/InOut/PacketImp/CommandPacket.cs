using System.IO;
using InOut.Utils;

namespace InOut.PacketImp
{
    public class CommandPacket : IPacket
    {

        public short Commande { get; set; }
        public int TargetChannel { get; set; }
        public byte[] Argument { get; set; }

        public CommandPacket()
        {

        }

        public CommandPacket(short cmd, int targetChannel, byte[] arg)
        {
            Commande = cmd;
            Argument = arg;
            TargetChannel = targetChannel;
        }

        public void Parse(byte[] packet)
        {
            Parse(new MemoryStream(packet));
        }

        public void Parse(Stream b)
        {
            Commande = b.ReadShort();
            TargetChannel = b.ReadInt32();
            Argument = new byte[b.Length - b.Position];
            b.Read(Argument, 0, Argument.Length);
        }

        public byte[] Build()
        {
            using (var memory = new MemoryStream())
            {
                memory.WriteShort(Commande);
                memory.WriteInt32(TargetChannel);
                memory.WriteBytes(Argument);
                return memory.ToArray();
            }
        }
    }
}
