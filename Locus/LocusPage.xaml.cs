using Locus.Geo;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Locus
{
    public partial class LocusPage : ContentPage
    {
        private static readonly ILogger logger = new ConsoleLogger(nameof(LocusPage));
        private readonly GeoLocator locator;

        public LocusPage()
        {
            InitializeComponent();

            locator = new GeoLocator();

            NavigateToMyLocation();
        }

        async void NavigateToMyLocation()
        {

            //logger.Info($"translating lat/long to address");
            //var geo = new Geocoder();
            //var geoTranslateTask = geo.GetAddressesForPositionAsync(new Xamarin.Forms.Maps.Position(latitude: 38.8951, longitude: -77.0364));
            //var geoTranslateResult = await geoTranslateTask;
            //logger.Info(geoTranslateResult);

            logger.Info($"querying for current location");

            GeoLocation geoLocation = await locator.CurrentLocationAsync();
            Position currentPosition = new Position(geoLocation.Latitude, geoLocation.Longitude);
            logger.Info($"current pos: {currentPosition}");

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(currentPosition, Distance.FromMiles(1)));
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
