using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterServiceAsync(UserCreateDto request);
        Task<string> LoginServiceAsync(UserLoginDto userLoginDto);

    }
}