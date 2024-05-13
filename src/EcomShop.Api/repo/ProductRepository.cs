using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class ProductRepository : IProduct
    {
        private readonly EcomShopDbContext _dbContext;

        public ProductRepository(EcomShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
                return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(ProductQueryOptions? options)
        {
            var query = _dbContext.Products.AsQueryable();
            if (options != null)
            {
                if (!string.IsNullOrEmpty(options.Name))
                {

                    var lowercaseTitle = options.Name.ToLower(); // Convert title to lowercase
                    query = query.Where(p => p.Name.ToLower().Contains(lowercaseTitle));

                }
                if (options.Min_Price.HasValue)
                {
                    query = query.Where(p => p.Price >= options.Min_Price.Value);
                }
                if (options.Max_Price.HasValue)
                {
                    query = query.Where(p => p.Price <= options.Max_Price.Value);
                }
                if (options.Category_Id.HasValue)
                {
                    query = query.Where(p => p.CategoryId == options.Category_Id);
                }
                if (!string.IsNullOrEmpty(options.SortBy))
                {
                    switch (options.SortBy.ToLower())
                    {
                        case "title":
                            query = options.SortOrder == "desc" ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name);
                            break;
                        case "price":
                            query = options.SortOrder == "desc" ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price);
                            break;

                        default:
                            // Default sorting by created date if sort by is not specified or invalid
                            query = options.SortOrder == "desc" ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id);
                            break;
                    }
                }
                query = query.Skip(options.Offset).Take(options.Limit);
            }
            var products = await query.ToListAsync(); ;
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoriesAsync(int categoryId)
        {
            return await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByPaginationAsync(int offset, int limit)
        {
            return await _dbContext.Products.Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal priceMin, decimal priceMax)
        {
            return await _dbContext.Products.Where(p => p.Price >= priceMin && p.Price <= priceMax).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsByNameAsync(string searchKey)
        {
            return await _dbContext.Products.Where(p => p.Name.Contains(searchKey)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortProductsByNameAsync(string sortOrder)
        {
            return sortOrder == "asc" ?
                await _dbContext.Products.OrderBy(p => p.Name).ToListAsync() :
                await _dbContext.Products.OrderByDescending(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortProductsByPriceAsync(string sortOrder)
        {
            return sortOrder == "asc" ?
                await _dbContext.Products.OrderBy(p => p.Price).ToListAsync() :
                await _dbContext.Products.OrderByDescending(p => p.Price).ToListAsync();
        }

        public async Task<bool> UpdateProductByIdAsync(Product product)
        {
            var existingProduct = await _dbContext.Products.FindAsync(product.Id);
            if (existingProduct == null)
                return false;

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}