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

            locator = GeoLocator.Instance;
            translator = GeoTranslator.Instance;

            NavigateToMyLocation();
            mapSlider.Value = 2;
        }

        async void NavigateToMyLocation()
        {
            logger.Info($"querying for current location");

            GeoLocation geoLocation = await locator.CurrentLocationAsync();
            logger.Info($"current location {geoLocation}");

            Position currentPosition = new Position(geoLocation.Latitude, geoLocation.Longitude);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition, Distance.FromMeters(100)));

            IEnumerable<string> address = await translator.GetAddressesForPositionAsync(geoLocation);
            if (address != null)
            {
                logger.Info(string.Join("\n", address).Replace("\n", ";"));
            }
        }

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            var zoomLevel = e.NewValue; 
            if (myMap.VisibleRegion != null)
            {
                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(myMap.VisibleRegion.Center, Distance.FromMeters(System.Math.Pow(2, zoomLevel))));
            }
        }
    }
}
