using System.ComponentModel.DataAnnotations;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.ValueObject;

namespace EcomShop.Application.src.DTO
{
    public class UserLoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public User CreateUser()
        {
            return new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password)
            };
        }
    }
    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public void Transform(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            PasswordHash = user.PasswordHash;
            Phone = user.Phone;
            Role = user.Role;
        }
        public User CreateUser(UserCreateDto userCreateDto)
        {
            return new User
            {
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email,
                PasswordHash = userCreateDto.PasswordHash,
                Phone = userCreateDto.Phone,
                Role = userCreateDto.Role
            };
        }
    }
    public class UserReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }

        public void Transform(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Phone = user.Phone;
            Role = user.Role;
        }

        public static IEnumerable<UserReadDto> ConvertList(IEnumerable<User> users)
        {
            var userReadDtos = new List<UserReadDto>();

            foreach (var user in users)
            {
                var userReadDto = new UserReadDto();
                userReadDto.Transform(user);
                userReadDtos.Add(userReadDto);
            }

            return userReadDtos;
        }
    }



    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public User UpdateUser(User oldUser)
        {
            oldUser.FirstName = FirstName;
            oldUser.LastName = LastName;
            oldUser.Phone = Phone;
            return oldUser;
        }
    }
}


