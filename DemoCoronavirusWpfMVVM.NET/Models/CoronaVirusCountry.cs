namespace DemoCoronavirusWpfMVVM.NET.Models
{
    // This class is used to store the country name, case count, and flag URI.
    public class CoronaVirusCountry
    {
        public string Country { get; set; } = string.Empty;
        public int CaseCount { get; set; } = 0;
        public string FlagUri { get; set; } = string.Empty;

    }
}
