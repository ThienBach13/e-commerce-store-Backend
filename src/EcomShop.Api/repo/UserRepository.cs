using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class UserRepository : BaseRepo<User, QueryOptions>, IUserRepository
    {
        public UserRepository(EcomShopDbContext context) : base(context)
        {
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _data.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> CreateUserAsync(User user)
        {

            var existingUser = await _data.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUser != null)
            {
                return false;
            }
            user.Id = Guid.NewGuid();
            _data.Add(user);
            await _databaseContext.SaveChangesAsync();

            return true;
        }
    }
}