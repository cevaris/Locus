using Locus.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Shared))]
namespace Locus.iOS
{
    public class Shared : IShared
    {
        private static readonly ILogger Logger = new ConsoleLogger(nameof(Shared));
    }
}