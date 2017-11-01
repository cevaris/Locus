using System;
namespace Locus
{
    public class Location
    {
        public double Latitude {get; set;}
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }

    public interface IShared
    {
        Location GetLocation();
    }
}
