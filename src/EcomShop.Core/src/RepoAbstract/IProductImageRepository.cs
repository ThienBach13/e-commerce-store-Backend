using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IProductImageRepository : IBaseRepository<ProductImage, QueryOptions>
    {
        Task<bool> CheckImageAsync(string image);
        Task<IEnumerable<ProductImage>> GetImageByProductIdAsync(Guid productId);
    }
}