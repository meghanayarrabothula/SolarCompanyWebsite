using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SolarCompanyWebsite.Services;
using SolarCompanyWebsite.Models;

namespace SolarCompanyWebsite.Controllers
{
    public class LocationController : Controller
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        // Show form to enter address
        public IActionResult Index()
        {
            return View();
        }

        // Handle form submission to get coordinates and solar data
        [HttpPost]
        public async Task<IActionResult> GetLocationData(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                ModelState.AddModelError("", "Please enter a valid address.");
                return View("Index");
            }

            // Get coordinates from the Geocoding API
            var coordinates = await _locationService.GetCoordinates(address);



            // Redirect to SolarDataController to fetch and display solar data
            return RedirectToAction("GetSolarData", "SolarData", new { latitude = coordinates.lat, longitude = coordinates.lng, address });

        }
        public IActionResult SolarEstimate()
        {
            return View();
        }

    }
}
