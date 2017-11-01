using Xamarin.Forms;

namespace Locus
{
    public partial class LocusPage : ContentPage
    {
        private static readonly ILogger Logger = new ConsoleLogger(nameof(LocusPage));

        public LocusPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Logger.Info(App.Shared.GetLocation());
        }
    }
}
