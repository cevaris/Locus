using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V4.Content;
using Android.Support.V4.App;

using Permission = Android.Content.PM.Permission;
// required for geo to work
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace Locus.Droid
{
    [Activity(Label = "Locus.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private readonly static ILogger logger = new ConsoleLogger(nameof(MainActivity));

        private const int REQUEST_ACCESS_FINE_LOCATION = 1001;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

            if (Android.OS.Build.VERSION.SdkInt <= Android.OS.BuildVersionCodes.M)
            {
                Permission permissionCheck = ContextCompat.CheckSelfPermission(
                    BaseContext, Manifest.Permission.AccessFineLocation
                );
                if (permissionCheck != Permission.Granted)
                {
                    ActivityCompat.RequestPermissions(
                        this,
                        new String[] { Manifest.Permission.AccessFineLocation },
                        REQUEST_ACCESS_FINE_LOCATION
                    );
                }
            }

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            switch (requestCode)
            {
                case REQUEST_ACCESS_FINE_LOCATION:
                    {
                        // If request is cancelled, the result arrays are empty.
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                        {
                            logger.Info("User ACCEPTED REQUEST_ACCESS_FINE_LOCATION!!");
                        }
                        else
                        {
                            logger.Info("User denied REQUEST_ACCESS_FINE_LOCATION");
                        }
                        return;
                    }
            }
        }

    }
}
