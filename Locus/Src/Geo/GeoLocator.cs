using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Locus.Geo
{
    public class GeoLocator
    {
        private readonly IGeolocator locator;
        private readonly TimeSpan timeout = TimeSpan.FromMilliseconds(2000);

        public GeoLocator()
        {
            locator = CrossGeolocator.Current;
        }

        public Task<GeoLocation> CurrentLocationAsync()
        {
            Task<Position> posTask = locator.GetPositionAsync(timeout);
            return posTask.ContinueWith(pos =>
            {
                GeoLocation loc = new GeoLocation()
                {
                    Latitude = pos.Result.Latitude,
                    Longitude = pos.Result.Longitude
                };
                return loc;
            });
        }
    }
}
