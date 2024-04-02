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

        // Override the OnStartup method 
        // This method is called when the application starts ...
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = new MainWindow()
            {
                // Set the DataContext of the MainWindow to a new instance of MainViewModel
                DataContext = new MainViewModel()
            };

            MainWindow.Show();
        }
    }
}
