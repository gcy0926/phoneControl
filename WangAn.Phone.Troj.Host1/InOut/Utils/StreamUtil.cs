using System;
using System.IO;
using System.Linq;

namespace InOut.Utils
{
    public static class StreamUtil
    {
        public static void WriteInt32(this Stream stream, int num)
        {
            const uint inital = 0xff;
            for (int i = 4-1; i >=0; i--)
            {
                var offset = 8*i;
                stream.WriteByte((byte)(((inital << offset) & num) >> offset));
            }
        }

        public static void WriteInt64(this Stream stream, long num)
        {
            const ulong inital = 0xff;
            var uNum = (ulong)num;
            for (int i = 8 - 1; i >= 0; i--)
            {
                var offset = 8*i;
                stream.WriteByte((byte)(((inital << offset) & uNum) >> offset));
            }
        }

        public static void WriteShort(this Stream stream, int num)
        {
            stream.WriteByte((byte)((0xff00 & num) >> 8));
            stream.WriteByte((byte)(0xff&num));
        }

        public static void WriteBytes(this Stream stream, byte[] bytes)
        {
            foreach (var b in bytes)
            {
                stream.WriteByte(b);
            }
        }

        public static int ReadInt32(this Stream stream)
        {
            var buffer = new Byte[4];
            stream.Read(buffer,0,buffer.Length);
            return buffer.Select((t, index) => (t << (buffer.Length - index - 1)*8)).Sum();
        }

        public static short ReadShort(this Stream stream)
        {
            var buffer = new byte[2];
            stream.Read(buffer, 0, buffer.Length);
            return (short)((buffer[0] << 8) + buffer[1]);
        }

        public static long ReadInt64(this Stream stream)
        {
            var buffer = new byte[8];
            stream.Read(buffer, 0, buffer.Length);
            return buffer.Select((t, i) => ((long) t << (buffer.Length - i - 1)*8)).Sum();
        }

    }
}
