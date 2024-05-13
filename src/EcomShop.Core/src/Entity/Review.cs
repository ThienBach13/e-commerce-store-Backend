using System.ComponentModel.DataAnnotations;

namespace EcomShop.Core.src.Entity
{
    public class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The UserId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "User Id must be a valid number.")]
        public int UserId { get; set; }
        // Navigation property for User
        public User? User { get; set; }

        [Required(ErrorMessage = "The Product Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Product Id must be a valid number.")]
        public int ProductId { get; set; }
        // Navigation property for Product
        public Product? Product { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        public DateTime Date { get; set; }

        [Range(0, 5, ErrorMessage = "The Rating field must be between 0 and 5.")]
        public decimal Rating { get; set; }

        [StringLength(1000, ErrorMessage = "The ReviewText field cannot exceed 1000 characters.")]
        public string? ReviewText { get; set; }
    }
}