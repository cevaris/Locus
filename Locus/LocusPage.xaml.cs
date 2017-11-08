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
            mapSlider.Value = 0;
        }

        async void NavigateToMyLocation()
        {
            logger.Info($"querying for current location");

            GeoLocation geoLocation = await locator.CurrentLocationAsync();
            logger.Info($"current location {geoLocation}");

            Position currentPosition = new Position(geoLocation.Latitude, geoLocation.Longitude);
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition, Distance.FromMeters(1)));

            IEnumerable<string> address = await translator.GetAddressesForPositionAsync(geoLocation);
            if (address != null)
            {
                logger.Info(string.Join("\n", address).Replace("\n", ";"));
            }
        }

        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            double zoomLevel = e.NewValue;
            if (myMap.VisibleRegion != null)
            {
                double meters = System.Math.Pow(3, zoomLevel);
                logger.Info($"new slider value={zoomLevel} meters={meters}");
                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(myMap.VisibleRegion.Center, Distance.FromMeters(meters)));
            }
        }
    }
}
