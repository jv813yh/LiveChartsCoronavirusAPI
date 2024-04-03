namespace DemoCoronavirusWpfMVVM.NET.Services.API.Models
{
    // API model for a country with the number of cases
    public class ApiCorovaVirusCountry
    {
        public string Country { get; set; } = string.Empty;
        public int Cases { get; set; }
    }
}
