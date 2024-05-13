
using System.Security.Claims;
using System.Text;
using EcomShop.Core.src.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Application.src.DTO;
namespace EcomShop.Application.src.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthenticationService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<bool> RegisterServiceAsync(UserCreateDto userRequest)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.PasswordHash);
            userRequest.PasswordHash = passwordHash;
            var rs = await _userService.CreateUserAsync(userRequest);
            return rs;
            // throw new NotImplementedException();
        }

        public async Task<string> LoginServiceAsync(UserLoginDto userLoginDto)
        {
            var rs = await _userService.GetUserByUserEmail(userLoginDto.Email);
            if (BCrypt.Net.BCrypt.Verify(userLoginDto.Password, rs.PasswordHash))
            {
                return CreateToken(rs);
            }
            throw new Exception("Invalid Email or Password");
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value!));

            // signing credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = credentials,
                Issuer = _configuration.GetSection("JwtSettings:Issuer").Value!,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenHandler.WriteToken(token);
        }
    }
}