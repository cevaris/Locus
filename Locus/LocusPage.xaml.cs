using System.Collections.Generic;
using Locus.Geo;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Locus
{
    public partial class LocusPage : ContentPage
    {
        private static readonly ILogger logger = new ConsoleLogger(nameof(LocusPage));
        private readonly GeoLocator locator;
        private readonly GeoTranslator translator;

        public LocusPage()
        {
            InitializeComponent();

            locator = new GeoLocator();
            translator = new GeoTranslator();

            NavigateToMyLocation();
        }

        async void NavigateToMyLocation()
        {
            logger.Info($"querying for current location");

            GeoLocation geoLocation = await locator.CurrentLocationAsync();
            logger.Info($"current location {geoLocation}");

            Position currentPosition = new Position(geoLocation.Latitude, geoLocation.Longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition, Distance.FromMeters(1)));

            IEnumerable<string> address = await translator.GetAddressesForPositionAsync(geoLocation);
            if (address != null)
            {
                logger.Info(string.Join("\n", address));
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
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
