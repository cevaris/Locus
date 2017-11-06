using System;
namespace Locus
{
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            return string.Format("[Location: Lat={0}, Long={1}]", Latitude, Longitude);
        }
    }
}
