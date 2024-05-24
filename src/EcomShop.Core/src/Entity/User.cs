using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcomShop.Core.src.ValueObject;

namespace EcomShop.Core.src.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Avatar is required.")]
        public string? Avatar { get; set; }
        public IEnumerable<Order>? Orders { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public Role Role { get; set; }

        public User(string name, string email, string password, string avatar, Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Avatar = avatar;
            Role = role;
        }

        public User()
        {
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

    }
}