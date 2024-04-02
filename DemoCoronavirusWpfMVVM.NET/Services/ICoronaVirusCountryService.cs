using DemoCoronavirusWpfMVVM.NET.Models;

namespace DemoCoronavirusWpfMVVM.NET.Services
{
    public interface ICoronaVirusCountryService
    {
        Task<IEnumerable<CoronaVirusCountry>> GetTopCountries(int amountOfCountries);
    }
}
