using DemoCoronavirusWpfMVVM.NET.Services;
using DemoCoronavirusWpfMVVM.NET.Services.API;

namespace DemoCoronavirusWpfMVVM.NET.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Property for binding (MainWindow.xaml)
        public CoronaVirusCountiresChartViewModel CoronaVirusCountiresChartViewModel { get; set; }

        public MainViewModel()
        {
            // Create a new instance of ApiCoronaVirusCountryService
            ICoronaVirusCountryService service = new ApiCoronaVirusCountryService();

            // Create a new instance of CoronaVirusCountiresChartViewModel
            CoronaVirusCountiresChartViewModel = CoronaVirusCountiresChartViewModel.CreateCoronaVirusCountiresChartViewModel(service);
        }
    }
}
