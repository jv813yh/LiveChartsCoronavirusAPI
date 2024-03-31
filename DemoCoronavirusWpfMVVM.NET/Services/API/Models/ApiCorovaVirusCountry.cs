namespace DemoCoronavirusWpfMVVM.NET.Services.API.Models
{
    public class ApiCorovaVirusCountry
    {
        public string Country { get; set; } = string.Empty;
        public int Cases { get; set; }
        public ApiCountryInfo CountryInfo { get; set; }
    }
}
