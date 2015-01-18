using System.IO;
using InOut.Utils;

namespace InOut.PacketImp
{
    public class FilePacket:IPacket
    {
        public byte[] Data { get; set; }
        public byte Mf { get; set; }
        public short NumSeq { get; set; }

        public FilePacket()
        {

        }

        public FilePacket(short num, byte mf, byte[] data)
        {
            this.Data = data;
            this.NumSeq = num;
            this.Mf = mf;
        }

        public byte[] Build()
        {
            using (var b = new MemoryStream(Data.Length + 3))
            {
                b.WriteShort(NumSeq);
                b.WriteByte(Mf);
                b.WriteBytes(Data);
                return b.ToArray();
            }
        }

        public void Parse(byte[] packet)
        {
            using (var b = new MemoryStream(packet))
            {
                NumSeq = b.ReadShort();
                Mf = (byte)b.ReadByte();
                Data = new byte[b.Length - b.Position];
                b.Read(Data, 0, Data.Length);    
            }

            
        }

        
    }
}
