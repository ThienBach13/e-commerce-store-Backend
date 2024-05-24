using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShop.Api.repo
{
    public class OrderedLineItemRepo : BaseRepo<OrderedLineItem, QueryOptions>, IOrderedLineItemRepository
    {
        public OrderedLineItemRepo(EcomShopDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<OrderedLineItem>> ListAsync(QueryOptions queryOptions)
        {
            var query = _data.AsQueryable();

            if (queryOptions.Page.HasValue && queryOptions.PageSize.HasValue)
            {
                query = query.Skip((queryOptions.Page.Value - 1) * queryOptions.PageSize.Value).Take(queryOptions.PageSize.Value);
            }

            return await query.ToListAsync();
        }
    }
}
