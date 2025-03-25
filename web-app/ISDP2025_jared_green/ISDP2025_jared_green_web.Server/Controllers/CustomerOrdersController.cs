using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Models;
using ISDP2025_jared_green_web.Server.Models.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISDP2025_jared_green_web.Server.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly ICustomerOrders _customerOrderService;
        private readonly ILogger<CustomerOrdersController> _logger;

        public CustomerOrdersController(ICustomerOrders customerOrderService, ILogger<CustomerOrdersController> logger)
        {
            _customerOrderService = customerOrderService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var result = await _customerOrderService.GetOrderByOrderID(id);

                if (result == null)
                    return NotFound("Order not found.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch order");
                return StatusCode(500, "An error occurred while querying the orders.");
            }
        }


        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> GetOrder([FromQuery] string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    return BadRequest("No Search Query");
                }

                if (int.TryParse(query, out int orderID))
                {
                    object result = await _customerOrderService.GetOrderByOrderID(orderID);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                } else
                {
                    object result = await _customerOrderService.GetOrderByCustomerEmail(query);
                    if (result != null) {
                        return Ok(result);
                    }
                }

                return NotFound("No order found for the given query");
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to fetch order");
                return StatusCode(500, "An error occurred while querying the orders.");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] dtoOrderCreation transaction)
        {
            try
            {
                dtoOrder? result = (await _customerOrderService.CreateOrder(transaction)) as dtoOrder;

                if (result == null)
                {
                    return BadRequest("Order Creation Failed");
                }
                else
                {
                    return CreatedAtAction(nameof(GetOrder), new { id = result.TxnId }, result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create order");
                return StatusCode(500, "An error occurred while creating the order.");
            }

        }        
    }
}
