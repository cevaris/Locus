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
            if(App.Shared.GetLocation() != null){
                CurrentLocation.Text = $"{App.Shared.GetLocation()}";    
            } else {
                CurrentLocation.Text = "Unknown";
            }
        }
    }
}
