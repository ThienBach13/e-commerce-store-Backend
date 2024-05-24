using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IOrderRepository : IBaseRepository<Order, QueryOptions>
    {
        Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(Guid customerId);
    }
}