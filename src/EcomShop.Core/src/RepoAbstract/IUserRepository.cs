using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IUserRepository : IBaseRepository<User, QueryOptions>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}