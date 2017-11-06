using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Locus.Geo
{
    public class GeoTranslator
    {
        private readonly Geocoder geocoder;

        public GeoTranslator()
        {
            geocoder = new Geocoder();
        }

        public Task<IEnumerable<string>> GetAddressesForPositionAsync(GeoLocation location)
        {
            Position mapsPosition = location.MapsPosition();
            return geocoder.GetAddressesForPositionAsync(mapsPosition);
        }
    }
}
