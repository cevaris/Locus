using System;
using CoreLocation;
using Locus;
using Locus.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Shared))]
namespace Locus.iOS
{
    public class Shared : IShared
    {
        private static readonly ILogger Logger = new ConsoleLogger(nameof(Shared));

        private LocationManager locManager { get; set; }

        public Shared()
        {
            locManager = new LocationManager();
            locManager.StartLocationUpdates();
        }

        public Location GetLocation()
        {
            return locManager.QueryLocation();
        }
    }
}

public class LocationManager
{
    private static readonly ILogger Logger = new ConsoleLogger(nameof(LocationManager));

    public Location CurrentLocation { get; set; }

    private CLLocationManager locMgr { get; set; }
    private event EventHandler<LocationUpdatedEventArgs> LocationUpdated = delegate { };

    public LocationManager()
    {
        locMgr = new CLLocationManager();
        locMgr.PausesLocationUpdatesAutomatically = true;

        // iOS 8 has additional permissions requirements
        if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
        {
            //locMgr.RequestAlwaysAuthorization(); // works in background
            locMgr.RequestWhenInUseAuthorization(); // only in foreground
        }
        // iOS 9
        if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
        {
            locMgr.AllowsBackgroundLocationUpdates = false;
        }
        LocationUpdated += LogLocation;
    }

    public Location QueryLocation()
    {
        return CurrentLocation;
    }

    public void StartLocationUpdates()
    {

        // We need the user's permission for our app to use the GPS in iOS. This is done either by the user accepting
        // the popover when the app is first launched, or by changing the permissions for the app in Settings
        if (CLLocationManager.LocationServicesEnabled)
        {
            //set the desired accuracy, in meters
            locMgr.DesiredAccuracy = 1;

            locMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
            {
                LocationUpdatedEventArgs newLocation = new LocationUpdatedEventArgs(e.Locations[e.Locations.Length - 1]);
                // fire our custom Location Updated event
                LocationUpdated(this, newLocation);
            };

            locMgr.StartUpdatingLocation();
        }
    }

    private void UpdateCurrentLocation(object sender, LocationUpdatedEventArgs e)
    {
        CLLocation location = e.Location;
        CurrentLocation = new Location()
        {
            Latitude = location.Coordinate.Latitude,
            Longitude = location.Coordinate.Longitude,
            Altitude = location.Altitude
        };
    }

    private void LogLocation(object sender, LocationUpdatedEventArgs e)
    {
        CLLocation location = e.Location;
        Logger.Info("Altitude: " + location.Altitude + " meters");
        Logger.Info("Longitude: " + location.Coordinate.Longitude);
        Logger.Info("Latitude: " + location.Coordinate.Latitude);
        Logger.Info("Course: " + location.Course);
        Logger.Info("Speed: " + location.Speed);
    }
}