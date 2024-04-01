using DemoCoronavirusWpfMVVM.NET.Services.API;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DemoCoronavirusWpfMVVM.NET
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApiCoronaVirusCountryService service = new ApiCoronaVirusCountryService();

            var result = await service.GetTopCountries(10);

        }
    }

}
