
using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class ProductImageRepository : BaseRepo<ProductImage, QueryOptions>, IProductImageRepository
    {
        public ProductImageRepository(EcomShopDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckImageAsync(string image)
        {
            return await _data.AnyAsync(p => p.Url == image);
        }

        public async Task<IEnumerable<ProductImage>> GetImageByProductIdAsync(Guid productId)
        {
            return await _data.Where(p => p.ProductId == productId).ToListAsync();
        }
    }
}