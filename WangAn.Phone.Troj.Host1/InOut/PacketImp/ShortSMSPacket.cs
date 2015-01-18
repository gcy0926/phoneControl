using System.CodeDom.Compiler;
using System.IO;
using InOut.Utils;

namespace InOut.PacketImp
{
    public class ShortSMSPacket:IPacket
    {
        public int AddressSize{ get; set; }
        public string Address{ get; set; }
        public long Date{ get; set; }
        public int BodySize{ get; set; }
        public string Body{ get; set; }

        public ShortSMSPacket()
        {

        }

        public ShortSMSPacket(string ad, long dat, string body)
        {
            Address = ad;
            AddressSize = ad.Len();
            Date = dat;
            Body = body;
            BodySize = Body.Len();
        }


        public byte[] Build()
        {
            var stream = new MemoryStream();
            stream.WriteInt32(AddressSize);
            stream.WriteBytes(Address.GetBytes());
            stream.WriteInt64(Date);
            stream.WriteInt32(BodySize);
            stream.WriteBytes(Body.GetBytes());
            return stream.ToArray();
        }

        public void Parse(byte[] packet)
        {
            var stream = new MemoryStream(packet);
            AddressSize = stream.ReadInt32();
            var tmp = new byte[AddressSize];
            stream.Read(tmp,0,tmp.Length);
            Address = tmp.ParseString();
            Date = stream.ReadInt64();
            BodySize = stream.ReadInt32();
            tmp = new byte[BodySize];
            stream.Read(tmp,0,tmp.Length);
            Body = tmp.ParseString();
        }

   
    }
}
