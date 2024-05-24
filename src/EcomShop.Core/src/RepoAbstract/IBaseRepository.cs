using EcomShop.Core.src.Common;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IBaseRepository<T, TQueryOptions> where T : class where TQueryOptions : QueryOptions
    {
        Task<IEnumerable<T>> GetListAsync(TQueryOptions options);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}