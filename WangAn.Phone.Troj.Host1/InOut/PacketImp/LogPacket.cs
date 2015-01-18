using System.IO;
using InOut.Utils;

namespace InOut.PacketImp
{
    public class LogPacket:IPacket
    {
        public long Date { get; set; }
        public byte Type { get; set; }
        public string Message { get; set; }

        public LogPacket()
        {

        }

        public LogPacket(long date, byte type, string message)
        {
            Date = date;
            Type = type;
            Message = message;
        }

        public byte[] Build()
        {
            byte[] messageBytes = Message.GetBytes();
            var mermoryStream = new MemoryStream(9 + messageBytes.Length);
            mermoryStream.WriteInt64(Date);
            mermoryStream.WriteByte(Type);
            mermoryStream.WriteBytes(messageBytes);
            return mermoryStream.ToArray();
        }

        public void Parse(byte[] packet)
        {
            var memoryStream = new MemoryStream(packet);
            Date = memoryStream.ReadInt64();
            Type = (byte)memoryStream.ReadByte();
            var tmp = new byte[memoryStream.Length - memoryStream.Position];
            memoryStream.Read(tmp, 0, tmp.Length);
            Message = tmp.ParseString();
        }


    }
}
