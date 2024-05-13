
using System.ComponentModel.DataAnnotations;

namespace EcomShop.Core.src.Entity
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The User Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "User Id must be a valid number.")]
        public int UserId { get; set; }
        // Navigation property for User
        public User? User { get; set; }
    }
}