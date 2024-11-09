using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SolarCompanyWebsite.Controllers.Api
{
    [Route("api/location/solarEstimate")]
    [ApiController]
    public class SolarEstimateApiController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSolarEstimate(string address)
        {
            // Call service to fetch solar estimate data for the provided address
            var solarEstimateData = await _solarEstimateService.GetEstimateForAddress(address);

            if (solarEstimateData == null)
                return NotFound();

            return Ok(solarEstimateData);
        }
    }
}
