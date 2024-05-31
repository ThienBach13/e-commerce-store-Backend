using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using EcomShop.Core.src.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class ProductRepository : BaseRepo<Product, QueryOptions>, IProductRepository
    {
        public ProductRepository(EcomShopDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product>> GetAllProductsAsync(QueryOptions? options)
        {
            var query = _data.Include(p => p.Category).Include(p => p.Images).AsQueryable();

            if (options != null)
            {
                switch (options.SortOrder)
                {
                    case SortOrder.Ascending:
                        query = query.OrderBy(p => p.Name); // Use a default property like Name or Price
                        break;
                    case SortOrder.Descending:
                        query = query.OrderByDescending(p => p.Name); // Use a default property like Name or Price
                        break;
                }

                // Pagination
                if (options.Page.HasValue && options.PageSize.HasValue)
                    query = query.Skip(options.Page.Value - 1).Take(options.PageSize.Value);
            }

            // Execute the query
            var products = await query.ToListAsync();
            return products;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            _data.Entry(entity).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return await _data
            .Include(p => p.Category)
            .Include(p => p.Images)
            .SingleOrDefaultAsync(p => p.Id == entity.Id);
        }

        public override async Task<Product> GetByIdAsync(Guid id)
        {
            return await _data
             .Include(p => p.Images)
             .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}