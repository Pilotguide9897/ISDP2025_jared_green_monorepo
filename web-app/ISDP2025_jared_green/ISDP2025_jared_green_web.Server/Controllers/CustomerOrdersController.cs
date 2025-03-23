using ISDP2025_jared_green_web.Server.Interfaces.Services;
using ISDP2025_jared_green_web.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISDP2025_jared_green_web.Server.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class CustomerOrdersController : ControllerBase
    {
        private readonly ICustomerOrders _customerOrderService;

        public CustomerOrdersController(ICustomerOrders customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var result = await _customerOrderService.GetOrderByOrderID(id);

            if (result == null)
                return NotFound("Order not found.");

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> GetOrder([FromQuery] int? id, [FromQuery] string? email)
        {
            object? result = null;

            if (id.HasValue)
            {
                result = await _customerOrderService.GetOrderByOrderID(id.Value);
            }
            else if (!string.IsNullOrWhiteSpace(email))
            {
                result = await _customerOrderService.GetOrderByCustomerEmail(email);
            }
            else
            {
                return BadRequest("You must provide either an order ID or email.");
            }

            if (result == null)
            {
                return BadRequest("Order could not be retrieved.");
            }
            else if (result is string)
            {
                return NotFound(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/orders")]
        public async Task<IActionResult> CreateOrder([FromBody] Txn transaction)
        {
            Txn? result = (await _customerOrderService.CreateOrder(transaction)) as Txn;

            if (result == null)
            {
                return BadRequest("Order Creation Failed");
            } else
            {
                return CreatedAtAction(nameof(GetOrder), new {id = result.TxnId}, result);
            }
        }
    }
}
