using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto, QueryOptions>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserByUserEmail(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }
    }
}