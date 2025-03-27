using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISDP2025_jared_green_web.Server.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : Controller
    {
        private readonly IInventory _inventoryService;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventory inventoryService, ILogger<InventoryController> logger) { 
            _inventoryService = inventoryService;
            _logger = logger;
        }


        //[Authorize(Roles ="Administrator,Delivery")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryBySite(int id)
        {
            try
            {
                var result = await _inventoryService.GetInventoryByLocation(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred fetching the site inventory for site id {id}: {ex}");
                return StatusCode(500, $"An error occurred fetching the site inventory for site id: {id}");
            }
        }
    }
}
