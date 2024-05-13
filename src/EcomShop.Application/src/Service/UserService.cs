using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // public Task<UserReadDto> CreateUserAsync(UserLoginDto user)
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<UserReadDto> CreateAdminAsync(UserCreateDto userDto)
        // {
        //     var user = userDto.CreateAdmin(new User());
        //     var createdUser = await _userRepository.CreateUserAsync(user);
        //     var userReadDto = new UserReadDto();
        //     userReadDto.Transform(createdUser);
        //     return userReadDto;
        // }
        public async Task<UserReadDto> CreateUserAsync(UserCreateDto userDto)
        {
            var user = userDto.CreateUser();
            var createdUser = await _userRepository.CreateUserAsync(user);
            var userReadDto = new UserReadDto();
            userReadDto.Transform(createdUser);
            return userReadDto;
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            return await _userRepository.DeleteUserByIdAsync(id);
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync(UserQueryOptions options)
        {
            var users = await _userRepository.GetAllUsersAsync(options);
            return UserReadDto.ConvertList(users);
        }

        // public Task<IEnumerable<UserReadDto>> GetAllUsersAsync(UserQueryOptions options)
        // {
        //     throw new NotImplementedException();
        // }
        public async Task<User> GetUserByUserEmail(string emmail)
        {
            return await _userRepository.GetUserByEmailAsync(emmail);
        }
        public async Task<UserReadDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            var userDto = new UserReadDto();
            userDto.Transform(user);
            return userDto;
        }

        public async Task<bool> UpdateUserByIdAsync(UserUpdateDto userDto)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userDto.Id);
            if (existingUser == null) return false;

            existingUser = userDto.UpdateUser(existingUser);
            return await _userRepository.UpdateUserByIdAsync(existingUser);
        }
    }
}