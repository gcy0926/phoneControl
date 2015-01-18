using System;
using System.ComponentModel;
using InOut.Utils;

namespace InOut.PacketImp
{
    [Serializable]
    public class CallLogPacket : IPacket
    {
        [Alias("list")]
        public CallPacket[] List { get; set; }

        public CallLogPacket()
        {

        }

        public CallLogPacket(CallPacket[] ar)
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
