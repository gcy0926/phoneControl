using System.IO;

namespace InOut.PacketImp
{
    public class GPSPacket : IPacket
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public float Speed { get; set; }
        public float Accuracy { get; set; }


        public GPSPacket()
        {

        }

        public GPSPacket(double lat, double lon, double alt, float speed, float acc)
        {
            Latitude = lat;
            Longitude = lon;
            Altitude = alt;
            Speed = speed;
            Accuracy = acc;
        }

        public byte[] Build()
        {
            using (var b = new MemoryStream(32))
            {
                //System.out.println("Longitude : "+Longitude);
                //b.putDouble(this.Longitude);
                //b.putDouble(this.Latitude);
                //b.putDouble(this.Altitude);
                //b.putFloat(this.Speed);
                //b.putFloat(this.Accuracy);        
                return b.ToArray();
            }


        }

        public void Parse(byte[] packet)
        {
            using (var b = new MemoryStream(packet))
            {
                //Longitude = b.getDouble();
                //Latitude = b.getDouble();
                //Altitude = b.getDouble();
                //Speed = b.getFloat();
                //Accuracy = b.getFloat();
            }
        }
    }
}
