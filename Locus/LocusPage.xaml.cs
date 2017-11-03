using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Locus
{
    public partial class LocusPage : ContentPage
    {
        private static readonly ILogger logger = new ConsoleLogger(nameof(LocusPage));

        public LocusPage()
        {
            InitializeComponent();


      
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            logger.Info($"translating lat/long to address");
            var geo = new Geocoder();
            var geoTranslateTask = geo.GetAddressesForPositionAsync(new Xamarin.Forms.Maps.Position(latitude: 38.8951, longitude: -77.0364));
            var geoTranslateResult = await geoTranslateTask;
            logger.Info(geoTranslateResult);

            logger.Info($"querying for current location");
            IGeolocator locator = CrossGeolocator.Current;
            Task<Plugin.Geolocator.Abstractions.Position> positionTask =
                locator.GetPositionAsync(TimeSpan.FromMilliseconds(2000));

            Plugin.Geolocator.Abstractions.Position positionGeoLoc = await positionTask;
            Xamarin.Forms.Maps.Position currentPosition = new Xamarin.Forms.Maps.Position(positionGeoLoc.Latitude, positionGeoLoc.Longitude);
            logger.Info($"current pos: {currentPosition}");

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition, Distance.FromMiles(1)));

            //logger.Info(App.Shared.GetLocation());
            //if (App.Shared.GetLocation() != null)
            //{
            //    CurrentLocation.Text = $"{App.Shared.GetLocation()}";
            //}
            //else
            //{
            //    CurrentLocation.Text = "Unknown";
            //}
        }
    }
}
