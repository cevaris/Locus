using CoreGraphics;
using Google.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Locus.Views.MapView), typeof(Locus.iOS.Views.MapViewRenderer))]
namespace Locus.iOS.Views
{
    public class MapViewRenderer : ViewRenderer
    {
        MapView underlyingView;

        private readonly static ILogger logger = new ConsoleLogger(nameof(MapViewRenderer));

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {
                
                CameraPosition camera = CameraPosition.FromCamera(
                    latitude: 37.797865,
                    longitude: -122.402526,
                    zoom: 6
                );

                underlyingView = MapView.FromCamera(CGRect.Empty, camera);
                SetNativeControl(underlyingView);
            }
        }
    }
}
