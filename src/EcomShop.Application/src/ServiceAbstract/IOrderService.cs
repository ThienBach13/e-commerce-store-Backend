using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IOrderService
    {
        // -- function to create a order to database
        Task<OrderReadDto> CreateOrderAsync(OrderCreateDto order);
        // -- function to get all order items
        Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync(OrderQueryOptions optins);
        // -- function to get all item in 1 order by ID
        Task<OrderReadDto> GetOrderByIdAsync(int id);
        // -- function to get all items by customer ID 
        Task<OrderReadDto> GetOrderByCustomerIdAsync(int customerId);
        // --function to delete all items in a order by order id
        Task<bool> DeleteOrderByIdAsync(int id);
    }
}