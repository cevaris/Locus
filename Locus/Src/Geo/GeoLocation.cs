using System;
namespace Locus
{
    public class GeoLocation
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format("[Location: Lat={0}, Long={1}]", Latitude, Longitude);
        }

        public Xamarin.Forms.Maps.Position MapsPosition()
        {
            return new Xamarin.Forms.Maps.Position(Latitude, Longitude);
        }
    }
}
