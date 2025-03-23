using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISDP2025_jared_green_web.Server.Controllers
{
    [ApiController]
    [Route("api/deliveries")]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveries _deliveryService;
        private readonly ILogger<DeliveriesController> _logger;

        public DeliveriesController(IDeliveries deliveries, ILogger<DeliveriesController> logger)
        {
            _deliveryService = deliveries;
            _logger = logger;
        }

        [Authorize(Roles = "Administrator,Delivery")]
        [HttpGet]
        public async Task<IActionResult> GetDeliveries()
        {
            try
            {
                var result = await _deliveryService.GetDeliveries();

                if (result == null || !result.Any())
                    return NoContent();

                return Ok(result);
            } catch (Exception ex) 
            {
                _logger.LogError(ex, "Failed to retrieve orders.");
                return StatusCode(500, "An error occurred while retrieving the orders.");
            }
        }
    }
}
