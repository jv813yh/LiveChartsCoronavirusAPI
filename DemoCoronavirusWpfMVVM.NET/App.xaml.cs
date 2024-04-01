using DemoCoronavirusWpfMVVM.NET.Services.API;
using DemoCoronavirusWpfMVVM.NET.ViewModels;
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

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            ApiCoronaVirusCountryService service = new ApiCoronaVirusCountryService();

            var result = await service.GetTopCountries(10);

            MainWindow.Show();
        }
    }

}
