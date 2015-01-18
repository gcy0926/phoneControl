using System.Collections.Generic;
using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class TemporaryStorage
    {

        private List<byte[]> dataTemp;

        private byte[] finalData;


        private int totalLength;
        private int lastPacketPosition;
        private int sizeCounter;
        private bool end;


        public TemporaryStorage()
        {

            dataTemp = new List<byte[]>();
            lastPacketPosition = -1;
            sizeCounter = 0;

        }

        public void Reset()
        {
            dataTemp = new List<byte[]>();
            lastPacketPosition = -1;
            sizeCounter = 0;
            end = false;
        }


        public short AddPacket(TransportPacket packet)
        {
            if (packet.NumSeq != (lastPacketPosition + 1))
                return (short)Protocol.PacketLost;
            if (!end)
            {
                totalLength = packet.TotalLength;
                end = packet.IsLast;
                sizeCounter += packet.LocalLength;
                dataTemp.Add(packet.Data);
                if (!end)
                {
                    lastPacketPosition++;
                    return (short)Protocol.PacketDone;
                }
                if (sizeCounter != totalLength)
                    return (short)Protocol.SizeError;

                int i = 0;
                finalData = new byte[totalLength];
                for (int n = 0; n < dataTemp.Count; n++)
                    for (int p = 0; p < dataTemp[n].Length; p++, i++)
                        finalData[i] = dataTemp[n][p];

                return (short)Protocol.AllDone;
            }
            return (short)Protocol.NoMore;
        }


        public List<byte[]> GetByteData()
        {
            return dataTemp;
        }

        public byte[] GetFinalData()
        {
            return finalData;
        }

        public int GetLastPacketPositionReceived()
        {
            return lastPacketPosition;
        }

        public int GetTotalSize()
        {
            return totalLength;
        }
    }
}
