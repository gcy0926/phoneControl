using System;
using System.ComponentModel;
using System.IO;
using InOut.Utils;

namespace InOut.PacketImp
{
    public class CallPacket : IPacket
    {
        [Alias("id")]
        public int Id { get; set; }
        [Alias("type")]
        public int Type { get; set; }
        [Alias("date")]
        public long Date { get; set; }
        [Alias("duration")]
        public long Duration { get; set; }
        [Alias("contact_id")]
        public int ContactId { get; set; }
        [Alias("phoneNumberSize")]
        public int PhoneNumberSize { get; set; }
        [Alias("phoneNumber")]
        public String PhoneNumber { get; set; }
        [Alias("nameSize")]
        public int NameSize { get; set; }
        [Alias("name")]
        public String Name { get; set; }

        public CallPacket()
        {
        }

        public CallPacket(int id, int type, long date, long duration, int contactId, String number, String name)
        {
            Id = id;
            Type = type;
            Date = date;
            Duration = duration;
            ContactId = contactId;
            PhoneNumber = number;
            PhoneNumberSize = PhoneNumber != null ? number.Length : 0;
            Name = name;
            NameSize = name != null ? name.Length : 0;
        }

        public byte[] Build()
        {
            using (var stream = new MemoryStream(4 * 5 + 8 * 2 + PhoneNumberSize + NameSize))
            {
                stream.WriteInt32(Id);

                stream.WriteInt32(Type);
                stream.WriteInt64(Date);
                stream.WriteInt64(Duration);
                stream.WriteInt32(ContactId);
                stream.WriteInt32(PhoneNumberSize);
                stream.WriteBytes(PhoneNumber.GetBytes());
                stream.WriteInt32(NameSize);
                stream.WriteBytes(Name.GetBytes());
                return stream.ToArray();
            }
        }

        public void Parse(byte[] packet)
        {
            using(var  b = new MemoryStream(packet))
            {
                Id = b.ReadInt32();
                Type = b.ReadInt32();
                Date = b.ReadInt64();
                Duration = b.ReadInt64();
                ContactId = b.ReadInt32();
                PhoneNumberSize = b.ReadInt32();
                var tmp = new byte[PhoneNumberSize];
                b.Read(tmp, 0, PhoneNumberSize);
                PhoneNumber = tmp.ParseString();

                NameSize = b.ReadInt32();
                tmp = new byte[NameSize];
                b.Read(tmp, 0, NameSize);
                Name = tmp.ParseString();    
            }
        }
    }
}
