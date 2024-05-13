using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly EcomShopDbContext _context;

        public OrderRepo(EcomShopDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(OrderQueryOptions options)
        {
            var query = _context.Orders.AsQueryable();

            // Implementing filtering
            if (options.From.HasValue)
                query = query.Where(o => o.OrderDate > options.From.Value);
            if (options.To.HasValue)
                query = query.Where(o => o.OrderDate > options.To.Value.AddDays(1));


            // // Implementing sorting
            // if (!string.IsNullOrWhiteSpace(options.SortBy))
            // {
            //     switch (options.SortBy.ToLower())
            //     {
            //         case "orderdate":
            //             query = options.SortOrder.ToLower() == "asc" ? query.OrderBy(u => u.OrderDate) : query.OrderByDescending(u => u.OrderDate);
            //             break;
            //         default:
            //             break;
            //     }
            // }

            // Implementing pagination
            if (options.Page > 0 && options.PageSize > 0)
                query = query.Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);


            return await query.ToListAsync();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByCustomerIdAsync(int customerId)
        {
            return await _context.Orders.FindAsync(customerId);
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
    }
}