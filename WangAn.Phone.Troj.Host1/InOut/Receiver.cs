using System;
using System.IO;
using System.Net.Sockets;
namespace InOut
{
    public class Receiver
    {
        private readonly byte[] receivedData;
        private readonly Stream inputStream;

        public Receiver(Socket s)
        {
            inputStream = new NetworkStream(s);
            receivedData = new byte[Protocol.MaxPacketSize];
        }

        public Stream Read()
        {
            int count = inputStream.Read(receivedData, 0, receivedData.Length);
            return new MemoryStream(receivedData, 0, count);
        }

        public Stream Read(Stream b)
        {
            int n;
            byte[] theRest;
            if (b.Position > 0 && b.Position < Protocol.HeaderLengthData)
            {
                theRest = new byte[b.Position];
                b.Position = 0;
                b.Read(theRest, 0, (int)b.Length);
                Array.Copy(theRest, 0, receivedData, 0, theRest.Length);
                n = inputStream.Read(receivedData, theRest.Length, Protocol.MaxPacketSize - theRest.Length);
                n += theRest.Length;
            }
            else
                n = inputStream.Read(receivedData, 0, receivedData.Length);

            return new MemoryStream(receivedData, 0, n);
        }
    }
}
