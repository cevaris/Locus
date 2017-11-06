using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace Locus.Geo
{
    public class GeoTranslator
    {
        private static GeoTranslator _instance;
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

        public static GeoTranslator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GeoTranslator();
                }
                return _instance;
            }
        }
    }
}
