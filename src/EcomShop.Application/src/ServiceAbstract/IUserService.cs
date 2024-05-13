using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IUserService
    {
        // Task<IEnumerable<UserReadDto>> GetAllUsersAsync(UserQueryOptions options);
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
        /* Function to get one user by ID: */
        Task<UserReadDto> GetUserByIdAsync(int userId);
        /* Function to update a user: */
        Task<bool> UpdateUserByIdAsync(UserUpdateDto user);
        /* Function to delete a user: */
        Task<bool> DeleteUserByIdAsync(int id);
        /* Function to Create a user: */
        Task<bool> CreateUserAsync(UserCreateDto user);

        Task<User> GetUserByUserEmail(string userName);
        // Task<UserReadDto> CreateAdminAsync(UserCreateDto user);
    }
}