using System;
using System.ComponentModel;
using InOut.Entity;
using InOut.Utils;

namespace InOut.PacketImp
{
    [Serializable]
    public class FileTreePacket : IPacket
    {
        [Alias("list")]
        public MyFile[] List { get; set; }

        public FileTreePacket()
        {

        }

        public FileTreePacket(MyFile[] ar)
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
