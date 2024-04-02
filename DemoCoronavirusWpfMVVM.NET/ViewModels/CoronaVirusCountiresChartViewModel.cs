using DemoCoronavirusWpfMVVM.NET.Models;
using DemoCoronavirusWpfMVVM.NET.Services;
using LiveCharts;
using System.Windows;

namespace DemoCoronavirusWpfMVVM.NET.ViewModels
{
    public class CoronaVirusCountiresChartViewModel : ViewModelBase
    {
        // Amount of countries to display on the chart
        private const int AmountOfCountries = 10;

        // Service to get the top countries
        private readonly ICoronaVirusCountryService _coronaVirusCountryService;

        // 
        public ChartValues<int> CoronaVirusCountriesCaseCounts { get; set; }

        // 
        public string[] CoronaVirusCountriesNames { get; set; }



        public CoronaVirusCountiresChartViewModel(ICoronaVirusCountryService coronaVirusCountryService)
        {
            _coronaVirusCountryService = coronaVirusCountryService;
        }


        /// <summary>
        /// Create a new instance of the view model and load the data for the chart asynchronously 
        /// </summary>
        /// <param name="coronaVirusCountryService"> Service to get the top countries </param>
        /// <returns> CoronaVirusCountiresChartViewModel </returns>
        public static CoronaVirusCountiresChartViewModel CreateCoronaVirusCountiresChartViewModel(ICoronaVirusCountryService coronaVirusCountryService)
        {
            CoronaVirusCountiresChartViewModel returnViewModel = new CoronaVirusCountiresChartViewModel(coronaVirusCountryService);


            returnViewModel.Load().ContinueWith((task) =>
            {
                if (task.IsFaulted)
                {
                    // Log the exception
                    MessageBox.Show("An error occurred while loading the data for the chart.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            return returnViewModel;
        }

        /// <summary>
        /// Load the data for the chart
        /// </summary>
        /// <returns></returns>
        public async Task Load()
        {
            // Get the top countries
            IEnumerable<CoronaVirusCountry> topCountries = await _coronaVirusCountryService.GetTopCountries(AmountOfCountries);

            // Set the case counts for the Y axis
            CoronaVirusCountriesCaseCounts = new ChartValues<int>(topCountries.Select(c => c.CaseCount));

            // Set the country names for the X axis
            CoronaVirusCountriesNames = topCountries.Select(c => c.Country).ToArray();
        }
    }
}
