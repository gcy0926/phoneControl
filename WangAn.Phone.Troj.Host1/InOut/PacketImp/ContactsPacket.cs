using System;
using System.ComponentModel;
using InOut.Entity;
using InOut.Utils;

namespace InOut.PacketImp
{
    [Serializable]
    public class ContactsPacket : IPacket
    {
        [Alias("list")]
        public Contact[] List { get; set; }

        public ContactsPacket()
        {
        }

        public ContactsPacket(Contact[] ar)
        {
            List = ar;
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
