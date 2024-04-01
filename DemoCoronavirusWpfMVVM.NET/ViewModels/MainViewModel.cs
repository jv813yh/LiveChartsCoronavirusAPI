namespace DemoCoronavirusWpfMVVM.NET.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public CoronaVirusCountiresChartViewModel CoronaVirusCountiresChartViewModel { get; set; }

        public MainViewModel()
        {
            CoronaVirusCountiresChartViewModel = new CoronaVirusCountiresChartViewModel();
        }
    }
}
