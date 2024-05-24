using System.Security.Claims;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.Service;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderedLineItemService _orderedLineItemService;

        public OrderController(IOrderService orderService, IOrderedLineItemService orderedLineItemService)
        {
            _orderService = orderService;
            _orderedLineItemService = orderedLineItemService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllOrdersAsync([FromQuery] QueryOptions options)
        {
            return Ok(await _orderService.GetAllAsync(options));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetOrderByIdAsync([FromRoute] Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(order);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrderAsync(OrderCreateDto orderDto)
        {
            var createdOrder = await _orderService.CreateAsync(orderDto);
            if (createdOrder == null)
            {
                return StatusCode(500, "Failed to create order");
            }
            return Ok(createdOrder);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid id)
        {
            return Ok(await _orderService.DeleteAsync(id));
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllOrderByUser()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orders = await _orderService.GetOrdersByUserIdAsync(Guid.Parse(id));
            return Ok(orders);

        }
    }
}