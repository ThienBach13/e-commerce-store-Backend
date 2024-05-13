using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> GetAllProductsAsync(ProductQueryOptions options);
        Task<ProductReadDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductReadDto>> GetProductsByPaginationAsync(int offset, int limit);
        Task<IEnumerable<ProductReadDto>> GetProductsByPriceRangeAsync(decimal priceMin, decimal priceMax);
        Task<IEnumerable<ProductReadDto>> GetProductsByCategoriesAsync(int categoryId);
        Task<IEnumerable<ProductReadDto>> SearchProductsByNameAsync(string searchKey);
        Task<IEnumerable<ProductReadDto>> SortProductsByPriceAsync(string sortOrder);
        Task<IEnumerable<ProductReadDto>> SortProductsByNameAsync(string sortOrder);
        Task<ProductReadDto> CreateProductAsync(ProductCreateDto product);
        Task<bool> UpdateProductByIdAsync(ProductUpdateDto product);
        Task<bool> DeleteProductByIdAsync(int id);
    }
}