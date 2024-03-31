using DemoCoronavirusWpfMVVM.NET.Models;
using DemoCoronavirusWpfMVVM.NET.Services.API.Models;
using System.Net.Http;
using System.Text.Json;

namespace DemoCoronavirusWpfMVVM.NET.Services.API
{
    public class ApiCoronaVirusCountryService : ICoronaVirusCountryService
    {
        public async Task<IEnumerable<CoronaVirusCountry>> GetTopCountries(int count)
        {

            using (HttpClient client = new HttpClient())
            {
                string requestUrl = "https://disease.sh/v3/covid-19/countries?sort=cases";

                HttpResponseMessage apiResponseMessage = await client.GetAsync(requestUrl);

                if(!apiResponseMessage.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Error getting countries data");
                }
                else
                {
                    string jsonResponse = await apiResponseMessage.Content.ReadAsStringAsync();

                    ApiCorovaVirusCountriesList? apiCoronaCountriesList = JsonSerializer
                        .Deserialize<ApiCorovaVirusCountriesList>(jsonResponse);

                    if(apiCoronaCountriesList == null)
                    {
                        throw new JsonException("Error deserializing countries data");
                    }

                    return apiCoronaCountriesList.Countries
                        .Take(count)
                        .Select(c => new CoronaVirusCountry
                        {
                            Country = c.Country,
                            CaseCount = c.Cases,
                            FlagUri = c.CountryInfo.Flag,
                        });
                }
            }
        }
    }
}
