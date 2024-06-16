using MAS_projekt_s22580.Context;
using MAS_projekt_s22580.Server.Services;
using MAS_projekt_s22580.Services.MAS_projekt_s22580.Services;
using MAS_projekt_s22580.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MAS_projekt_s22580.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController: ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Retrieves all orders with basic information.
        /// </summary>
        /// <returns>A collection of OrderForList objects.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersForList()
        {
            var orders = await _orderService.GetAllOrdersForList();
            return Ok(orders);
        }

        /// <summary>
        /// Retrieves orders for a specific client by client ID.
        /// </summary>
        /// <param name="Id">The ID of the client.</param>
        /// <returns>A collection of OrderForList objects.</returns>
        [HttpGet("{Id}/client")]
        public async Task<IActionResult> GetOrdersForClient(int Id)
        {
            if (!await _orderService.DoesClientExists(Id)) { 
                NotFound();
            } 
            return Ok(await _orderService.GetOrdersForClient(Id));
        }

        /// <summary>
        /// Retrieves detailed information for a specific order by order ID.
        /// </summary>
        /// <param name="Id">The ID of the order.</param>
        /// <returns>An OrderDetails object.</returns>
        [HttpGet("details/{Id}")]
        public async Task<IActionResult> GetOrderById(int Id)
        {
            if (!await _orderService.DoesOrderExists(Id))
            {
                NotFound();
            }
            return Ok(await _orderService.GetOrderDetailsById(Id));
        }

        /// <summary>
        /// Updates the details of a specific order by order ID.
        /// </summary>
        /// <param name="id">The ID of the order to update.</param>
        /// <param name="orderDetails">The updated order details.</param>
        /// <returns>An IActionResult indicating the result of the update operation.</returns>
        [HttpPut("details/{id}")]
        public async Task<IActionResult> UpdateOrderDetails(int id, [FromBody] OrderDetails orderDetails)
        {
            if (id != orderDetails.Id)
            {
                return BadRequest();
            }
            if (!await _orderService.DoesOrderExists(id))
            {
                NotFound();
            }
            await _orderService.UpdateOrderStatus(id, orderDetails.Status);
            return Ok();
        }
    }
}
