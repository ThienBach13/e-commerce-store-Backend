using System.ComponentModel.DataAnnotations;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.ValueObject;

namespace EcomShop.Application.src.DTO
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Avatar { get; set; }
        public Role Role { get; set; }
    }

    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Avatar { get; set; }

    }

    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
    }
}


