using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IUserRepository
    {
        // Task<IEnumerable<User>> GetAllUsersAsync(UserQueryOptions options);
        Task<IEnumerable<User>> GetAllUsersAsync();
        /* Function to get one user by ID: */
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        /* Function to update a user: */
        Task<bool> UpdateUserByIdAsync(User user);
        /* Function to delete a user: */
        Task<bool> DeleteUserByIdAsync(int id);
        /* Function to Create a user: */
        Task<bool> CreateUserAsync(User user);

    }
}