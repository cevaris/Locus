using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
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
            global::Xamarin.FormsMaps.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
