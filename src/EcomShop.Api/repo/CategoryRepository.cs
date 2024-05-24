using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class CategoryRepository : BaseRepo<Category, QueryOptions>, ICategoryRepository
    {
        public CategoryRepository(EcomShopDbContext context) : base(context)
        {
        }
    }
}