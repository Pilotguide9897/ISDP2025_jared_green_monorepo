using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISDP2025_jared_green_web.Server.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController : ControllerBase
    {

        private readonly ILocations _locationService;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocations locationService, ILogger<LocationController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        [Authorize(Roles = "Administrator,Delivery")]
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var locations = await _locationService.GetAllLocations();

                if (locations == null || !locations.Any())
                    return NoContent();

                return Ok(locations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve locations.");
                return StatusCode(500, "An error occurred while retrieving the locations.");
            }
        }

        [Authorize(Roles = "Administrator,Delivery")]
        [HttpGet("/retail")]
        public async Task<IActionResult> GetRetailLocations()
        {
            try
            {
                var retailLocations = await _locationService.GetRetailLocations();

                if (retailLocations == null || !retailLocations.Any())
                    return NoContent();

                return Ok(retailLocations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve all retail locations.");
                return StatusCode(500, "An error occurred while retrieving the retail locations.");
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationByID(int id)
        {
            try
            {
                var location = await _locationService.GetLocationBySiteID(id);

                if (location == null)
                    return NotFound("Site not found.");


                return Ok(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve retail location.");
                return StatusCode(500, "An error occurred while retrieving the location data.");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetLocationByEmployee()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}
