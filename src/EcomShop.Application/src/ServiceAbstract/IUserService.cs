using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IUserService : IBaseService<UserReadDto, UserCreateDto, UserUpdateDto, QueryOptions>
    {
        Task<User> GetUserByUserEmail(string userName);
    }
}