using System;
using System.ComponentModel;
using InOut.Utils;

namespace InOut.PacketImp
{
    [Serializable]
    public class SMSPacket : IPacket
    {

        [Alias("id")]
        public int Id { get; set; }
        [Alias("thread_id")]
        public int ThreadId { get; set; }
        [Alias("address")]
        public String Address { get; set; }
        [Alias("person")]
        public int Person { get; set; }
        [Alias("date")]
        public long Date { get; set; }
        [Alias("read")]
        public int Read { get; set; }
        [Alias("type")]
        public int Type { get; set; }
        [Alias("body")]
        public String Body { get; set; }

        public SMSPacket()
        {

        }

        public SMSPacket(int id, int thid, String ad, int pers, long dat, int read, String body, int type)
        {
            Id = id;
            ThreadId = thid;
            Address = ad;
            Person = pers;
            Date = dat;
            Read = read;
            Body = body;
            Type = type;
        }


        public byte[] Build()
        {
            return PacketUtil.Build(this);
        }

        public void Parse(byte[] packet)
        {
            PacketUtil.Parse(packet, this);
        }
    }
}
