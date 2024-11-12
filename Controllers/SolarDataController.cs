using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SolarCompanyWebsite.Models;
using SolarCompanyWebsite.Services;

namespace SolarCompanyWebsite.Controllers
{
    public class SolarDataController : Controller
    {
        private readonly SolarDataService _solarDataService;

        public SolarDataController(SolarDataService solarDataService)
        {
            _solarDataService = solarDataService;
        }

        // Method to retrieve solar data based on latitude and longitude
        public async Task<IActionResult> GetSolarData(float latitude, float longitude, string address)
        {
            // Fetch solar data using SolarDataService
            var solarData = await _solarDataService.GetSolarPotentialData(latitude, longitude);

            // Pass data to the view
            ViewBag.Address = address;
            ViewBag.Latitude = latitude;
            ViewBag.Longitude = longitude;
            ViewBag.SolarData = solarData;

            return View("SolarData"); // Ensure a view named SolarData.cshtml exists
        }
    }
}
