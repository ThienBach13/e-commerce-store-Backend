using System.ComponentModel.DataAnnotations;
using EcomShop.Core.src.ValueObject;

namespace EcomShop.Core.src.Entity
{
    public class User
    {
        public int Id { get; set; }
        // [Required(ErrorMessage = "First name is required.")]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "First name must contain only letters and spaces.")]
        public string FirstName { get; set; }

        // [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Last name must contain only letters and spaces.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        // [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string PasswordHash { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")] public string Phone { get; set; }

        // [Required(ErrorMessage = "Password is required.")]
        // [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        // public string Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public Role Role { get; set; }

    }
}