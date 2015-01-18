using System;
using System.IO;
using InOut.PacketImp;

namespace InOut
{
    public class Demux
    {
        private readonly IController controler;

        private TransportPacket p;

        public String Imei { private get; set; }

        private bool partialDataExpected, reading;

        public Demux(IController s, String i)
        {
            Imei = i;
            controler = s;
            reading = true;
            partialDataExpected = false;

        }

        public bool Receive(Stream stream)
        {
            while (reading)
            {
                if (!partialDataExpected)
                {
                    if ((stream.Length - stream.Position) < Protocol.HeaderLengthData)
                    {
                        return true;
                    }
                }
                
                if (partialDataExpected)
                    partialDataExpected = p.ParseCompleter(stream);
                else
                {
                    p = new TransportPacket();
                    partialDataExpected = p.Parse(stream);
                }
                if (partialDataExpected)
                    return true;
                controler.Storage(p, Imei);
            }


            reading = true;
            return true;
        }

    }
}
