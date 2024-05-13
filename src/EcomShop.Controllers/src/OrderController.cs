using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using Microsoft.AspNetCore.Mvc;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync([FromQuery] OrderQueryOptions options)
        {
            try
            {
                return await _orderService.GetAllOrdersAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<OrderReadDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrderAsync(OrderCreateDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Invalid request body");
            }

            var createdOrder = await _orderService.CreateOrderAsync(orderDto);
            if (createdOrder == null)
            {
                return StatusCode(500, "Failed to create order");
            }

            return createdOrder;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderByIdAsync(id);

            if (!result)
            {
                return NotFound($"Order with ID {id} not found");
            }

            return NoContent();
        }

        [HttpGet("customer")]
        public async Task<OrderReadDto> GetOrderByCustomerIdAsync(int customerId)
        {
            var order = await _orderService.GetOrderByCustomerIdAsync(customerId);
            return order;
        }
    }
}