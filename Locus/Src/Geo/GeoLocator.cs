using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Locus.Geo
{
    public class GeoLocator
    {
        private static GeoLocator _instance;
        private readonly IGeolocator locator;
        private readonly TimeSpan timeout = TimeSpan.FromMilliseconds(2000);
        private readonly static ILogger logger = new ConsoleLogger(nameof(GeoLocator));

        public GeoLocator()
        {
            locator = CrossGeolocator.Current;
        }

        public Task<GeoLocation> CurrentLocationAsync()
        {
            Task<Position> posTask = locator.GetPositionAsync(timeout);
            return posTask.ContinueWith(pos =>
            {
                GeoLocation loc = new GeoLocation(
                    pos.Result.Latitude,
                    pos.Result.Longitude
                );
                return loc;
            });
        }

        public static GeoLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GeoLocator();
                }
                return _instance;
            }
        }
    }
}
