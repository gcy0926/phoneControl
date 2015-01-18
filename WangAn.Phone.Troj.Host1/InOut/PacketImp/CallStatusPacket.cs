using System;
using System.IO;
using InOut.Utils;


namespace InOut.PacketImp
{
    public class CallStatusPacket : IPacket
    {
        [Alias("type")]
        public int Type { get; set; }
        /*
         * 1 -> Incoming call
         * 2 -> Missed call
         * 3 -> Call accepted
         * 4 -> Call send
         * 5 -> Hang Up
         * 
        */
        [Alias("dateSize")]
        public int DateSize { get; set; }
        [Alias("date")]
        public string Date { get; set; }
        [Alias("phonenumberSize")]
        public int PhonenumberSize { get; set; }
        [Alias("phonenumber")]
        public string Phonenumber { get; set; }
        [Alias("phonedata")]
        public byte[] Phonedata { get; set; }

        public CallStatusPacket()
        {

        }

        public CallStatusPacket(int type, string phonenumber, string date, byte[] phonedata)
        {
            Type = type;
            Phonenumber = phonenumber;
            Date = date;
            DateSize = Date != null ? date.Length : 0;
            PhonenumberSize = Phonenumber != null ? phonenumber.Length : 0;
            Phonedata = phonedata;

        }

        public byte[] Build()
        {
            using (var memory = new MemoryStream(500))
            {
                memory.WriteInt32(Type);
                memory.WriteInt32(DateSize);
                memory.WriteBytes(Date.GetBytes());
                memory.WriteInt32(PhonenumberSize);
                memory.WriteBytes(Phonenumber.GetBytes());
                memory.WriteBytes(Phonedata);
                return memory.ToArray();
            }

        }

        public void Parse(byte[] packet)
        {
            using (var memory = new MemoryStream(packet))
            {
                Type = memory.ReadInt32();
                if (memory.Position != memory.Length)
                {
                    var tmp = new byte[19];
                    memory.Read(tmp, 0, 19);
                    Date = tmp.ParseString();
                    tmp = new byte[11];
                    memory.Read(tmp, 0, 11);
                    Phonenumber = tmp.ParseString();
                    tmp = new byte[memory.Length - memory.Position];
                    int i = (int)(memory.Length - memory.Position);
                    memory.Read(tmp, 0, i);
                    Phonedata = tmp;
                }

            }
        }
    }
}
