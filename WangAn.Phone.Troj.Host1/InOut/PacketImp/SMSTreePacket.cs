using System;
using System.ComponentModel;
using InOut.Utils;

namespace InOut.PacketImp
{
    [Serializable]
    public class SMSTreePacket : IPacket
    {
        [Alias("list")]
        public SMSPacket[] List { get; set; }

        public SMSTreePacket()
        {

        }

        public SMSTreePacket(SMSPacket[] ar)
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
