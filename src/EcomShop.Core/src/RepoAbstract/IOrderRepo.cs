using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IOrderRepo
    {
        // -- function to create a order to database
        Task<Order> CreateOrderAsync(Order order);
        // -- function to get all order items
        Task<IEnumerable<Order>> GetAllOrdersAsync(OrderQueryOptions optins);
        // -- function to get all item in 1 order by ID
        Task<Order> GetOrderByIdAsync(int id);
        // -- function to get all items by customer ID 
        Task<Order> GetOrderByCustomerIdAsync(int customerId);
        // --function to delete all items in a order by order id
        Task<bool> DeleteOrderByIdAsync(int id);
    }
}