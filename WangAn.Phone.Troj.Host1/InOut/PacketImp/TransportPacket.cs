using System;
using System.IO;
using InOut.Utils;

namespace InOut.PacketImp
{
    public class TransportPacket : IPacket
    {

        public int TotalLength { get; private set; }

        private int awaitedLength;
        public int LocalLength { get; private set; }
        public bool IsLast { get; private set; }
        public short NumSeq { get; private set; }
        public int Channel { get; private set; }
        public byte[] Data { get; private set; }

        private int fillingPosition;

        public TransportPacket()
        {
            awaitedLength = 0;
            fillingPosition = 0;

        }

        public TransportPacket(int totalLength, int localLength, int channel, bool last,
                short nums, byte[] data)
        {
            TotalLength = totalLength;
            Channel = channel;
            IsLast = last;
            Data = data;
            LocalLength = localLength;
            NumSeq = nums;
        }

        public void Parse(byte[] packet)
        {
            var stream = new MemoryStream(packet);
            TotalLength = stream.ReadInt32();
            LocalLength = stream.ReadInt32();

            int checkLast = stream.ReadByte();
            IsLast = checkLast == 1;

            NumSeq = stream.ReadShort();
            Channel = stream.ReadInt32();

            Data = new byte[packet.Length - Protocol.HeaderLengthData];
            stream.Read(Data, 0, Data.Length);
        }

        public bool Parse(Stream stream)
        {

            TotalLength = stream.ReadInt32();
            LocalLength = stream.ReadInt32();
            if (LocalLength > 0)
            {
                int checkLast = stream.ReadByte();
                IsLast = checkLast == 1;

                NumSeq = stream.ReadShort();
                Channel = stream.ReadInt32();

                if ((stream.Length - stream.Position) < LocalLength)
                {
                    DataFilling(stream, (int)(stream.Length - stream.Position));
                    return true;

                }
                Data = new byte[LocalLength];
                stream.Read(Data, 0, Data.Length);  
            }
            return false;
        }

        public bool ParseCompleter(Stream buffer)
        {
            if (buffer.Length - buffer.Position < awaitedLength)
            {
                DataFilling(buffer, (int)(buffer.Length - buffer.Position));
                return true;
            }
            DataFilling(buffer, awaitedLength);
            return false;
        }

        public void DataFilling(Stream buffer, int length)
        {
            if (Data == null)
                Data = new byte[LocalLength];

            buffer.Read(Data, fillingPosition, length);
            fillingPosition += length;
            awaitedLength = LocalLength - fillingPosition;

        }

        public byte[] Build()
        {
            byte[] cmdToSend = new byte[Protocol.HeaderLengthData + Data.Length];

            byte[] header = Protocol.DataHeaderGenerator(TotalLength,
                    LocalLength,IsLast, NumSeq, Channel);

            Array.Copy(header, 0, cmdToSend, 0, header.Length);
            Array.Copy(Data, 0, cmdToSend, header.Length, Data.Length);

            return cmdToSend;
        }

    }
}
