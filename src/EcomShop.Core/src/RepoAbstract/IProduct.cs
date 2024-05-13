using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IProduct
    {
        Task<Product> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync(ProductQueryOptions options);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByPaginationAsync(int offset, int limit);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal priceMin, decimal priceMax);
        Task<IEnumerable<Product>> GetProductsByCategoriesAsync(int categoryId);
        Task<IEnumerable<Product>> SearchProductsByNameAsync(string searchKey);
        Task<IEnumerable<Product>> SortProductsByPriceAsync(string sortOrder);
        Task<IEnumerable<Product>> SortProductsByNameAsync(string sortOrder);
        Task<bool> UpdateProductByIdAsync(Product product);
        Task<bool> DeleteProductByIdAsync(int id);
    }
}