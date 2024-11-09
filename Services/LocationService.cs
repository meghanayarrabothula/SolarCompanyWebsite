using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SolarCompanyWebsite.Models;

namespace SolarCompanyWebsite.Services
{
    public class LocationService
    {
        private readonly HttpClient _httpClient;
        private const string GoogleGeocodeApiKey = "My Key";
        private const string GoogleGeocodeUrl = "https://maps.googleapis.com/maps/api/geocode/json";
        private const string GoogleSolarApiUrl = "https://solar.googleapis.com/v1/buildingInsights:findClosest";

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get coordinates from an address
        public async Task<Location> GetCoordinates(string address)
        {
            var formattedAddress = address.Replace(" ", "%20");
            var url = $"{GoogleGeocodeUrl}?address={formattedAddress}&key={GoogleGeocodeApiKey}";

            var response = await _httpClient.GetStringAsync(url);
            var geocodeResponse = JsonConvert.DeserializeObject<GeocodeResponse>(response);

            return geocodeResponse.results[0].geometry.location;
        }

        // Method to get solar data based on coordinates
        public async Task<string> GetSolarData(float latitude, float longitude)
        {
            var url = $"{GoogleSolarApiUrl}?location.latitude={latitude}&location.longitude={longitude}&key={GoogleGeocodeApiKey}";
            var response = await _httpClient.GetStringAsync(url);

            return response; // Returns the raw JSON response for solar data.
        }
    }
}
