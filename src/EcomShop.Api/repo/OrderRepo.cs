using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class OrderRepo : BaseRepo<Order, QueryOptions>, IOrderRepository
    {

        public OrderRepo(EcomShopDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(Guid customerId)
        {
            return await _data.Where(o => o.UserId == customerId).ToListAsync();
        }
    }
}