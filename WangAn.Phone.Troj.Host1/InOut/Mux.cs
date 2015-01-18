using InOut.PacketImp;
using System;
using System.IO;

namespace InOut
{
    public class Mux
    {
        private readonly Sender sender;

        public Mux(Stream stream)
        {
            sender = new Sender(stream);
        }


        public void Send(int chan, byte[] data)
        {
            try
            {
                bool last = false;
                bool envoieTotal = false;
                int pointeurData = 0;
                short numSeq = 0;

                while (!envoieTotal)
                {
                    byte[] dataToSend;

                    if (last || ((Protocol.HeaderLengthData + data.Length) < Protocol.MaxPacketSize))
                    {
                        dataToSend = new byte[Protocol.HeaderLengthData + (data.Length - pointeurData)];
                        last = true;
                        envoieTotal = true;
                    }
                    else
                        dataToSend = new byte[Protocol.MaxPacketSize];


                    int actualLenght = dataToSend.Length - Protocol.HeaderLengthData;


                    var fragData = new byte[dataToSend.Length - Protocol.HeaderLengthData];
                    Array.Copy(data, pointeurData, fragData, 0, fragData.Length);
                    var tp = new TransportPacket(data.Length, actualLenght, chan, last, numSeq, fragData);
                    dataToSend = tp.Build();
                    pointeurData = pointeurData + actualLenght;
                    numSeq++;
                    if ((data.Length - pointeurData) <= (Protocol.MaxPacketSize - Protocol.HeaderLengthData))
                    {
                        last = true;
                    }

                    sender.Send(dataToSend);

                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
