using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class BaseRepo<T, TQueryOptions> : IBaseRepository<T, TQueryOptions>
        where T : class
        where TQueryOptions : QueryOptions
    {
        protected readonly DbSet<T> _data;
        protected readonly EcomShopDbContext _databaseContext;
        public BaseRepo(EcomShopDbContext databaseContext)
        {
            _databaseContext = databaseContext;
            _data = _databaseContext.Set<T>();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            _data.Add(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var find = await _data.FindAsync(id);
            _data.Remove(find);
            _databaseContext.SaveChanges();
            return true;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _data.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(TQueryOptions options)
        {
            return await _data.Skip(options.Page.Value - 1).Take(options.PageSize.Value).ToListAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _data.Entry(entity).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return entity;
        }
    }
}