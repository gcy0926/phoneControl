using System.IO;

namespace InOut
{
    public class Sender
    {
        private readonly Stream stream;

        public Sender(Stream stream)
        {
            this.stream = stream;
        }

        public void Send(byte[] data)
        {
            try
            {
                stream.Write(data, 0, data.Length);
            }
            catch (IOException e)
            {

            }
        }
    }
}
