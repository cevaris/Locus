using System;
namespace Locus
{
    public class Location
    {
        public double Latitude {get; set;}
        public double Longitude { get; set; }

        public override string ToString()
        {
            return string.Format("[Location: Latitude={0}, Longitude={1}]", Latitude, Longitude);
        }
    }

    public interface IShared
    {
        Location GetLocation();
    }
}
