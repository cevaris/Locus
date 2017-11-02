using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.Maps;
using UIKit;

using Locus;

namespace Locus.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private readonly static ILogger logger = new ConsoleLogger(nameof(AppDelegate));

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            MapServices.ProvideAPIKey(Secrets.MapsApiKey);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
