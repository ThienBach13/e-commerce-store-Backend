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

        public async override Task<IEnumerable<Order>> GetListAsync(QueryOptions options)
        {
            var orders = await _data.Include(o => o.OrderItems).ToListAsync();
            return orders;
        }

        public async override Task<Order> GetByIdAsync(Guid id)
        {
            return await _data.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> DeleteOrderByIdAsync(Guid id)
        {
            var order = await _data.FindAsync(id);
            if (order == null)
                return false;

            _data.Remove(order);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> GetOrderByCustomerIdAsync(Guid customerId)
        {
            var orders = await _data.Where(o => o.UserId == customerId).ToListAsync();
            foreach (var order in orders)
            {
                await _databaseContext.Entry(order)
                    .Collection(o => o.OrderItems)
                    .LoadAsync();
            }
            return orders;
        }

    }
}