using DemoCoronavirusWpfMVVM.NET.Models;
using DemoCoronavirusWpfMVVM.NET.Services.API.Models;
using System.Net.Http;
using System.Text.Json;

namespace DemoCoronavirusWpfMVVM.NET.Services.API
{
    // This class is responsible for fetching the top countries with the most cases of coronavirus
    public class ApiCoronaVirusCountryService : ICoronaVirusCountryService
    {
        // Method to get the top countries with the most cases of coronavirus
        // Uses HttpClient to make a GET request to the disease.sh API
        public async Task<IEnumerable<CoronaVirusCountry>> GetTopCountries(int amountOfCountries)
        {
            // Create a new HttpClient object
            using (HttpClient client = new HttpClient())
            {
                // Set the request URL
                string requestUrl = "https://disease.sh/v3/covid-19/countries?sort=cases";

                // Make a GET request to the API
                HttpResponseMessage apiResponseMessage = await client.GetAsync(requestUrl);

                // Check if the request was successful
                if(!apiResponseMessage.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Error getting countries data");
                }
                else
                {
                    // Read the response content as a string
                    string jsonResponse = await apiResponseMessage.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into an List of ApiCorovaVirusCountry objects
                    List<ApiCorovaVirusCountry>? apiCoronaCountriesList = JsonSerializer
                        .Deserialize<List<ApiCorovaVirusCountry>>(jsonResponse, new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });

                    if (apiCoronaCountriesList == null)
                    {
                        throw new JsonException("Error deserializing countries data");
                    }

                    // Return the top countries with the most cases
                    return apiCoronaCountriesList
                        .Take(amountOfCountries)
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
