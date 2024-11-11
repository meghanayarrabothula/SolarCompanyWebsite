using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SolarCompanyWebsite.Models;

namespace SolarCompanyWebsite.Services
{
    public class SolarDataService
    {
        private readonly HttpClient _httpClient;
        private const string GoogleSolarApiUrl = "https://solar.googleapis.com/v1/buildingInsights:findClosest";
        private const string GoogleGeocodeApiKey = "AIzaSyCoIQ5_W_uCCRywMXI2ep5nBeXQ4ZZpmOU";

        public SolarDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SolarPotential> GetSolarPotentialData(float latitude, float longitude)
        {
            var url = $"{GoogleSolarApiUrl}?location.latitude={latitude}&location.longitude={longitude}&key={GoogleGeocodeApiKey}";
            var response = await _httpClient.GetStringAsync(url);

            // Deserialize the JSON response into the SolarPotential model
            var solarData = JsonConvert.DeserializeObject<SolarResponse>(response);

            return solarData.solarPotential;
        }
    }
}
