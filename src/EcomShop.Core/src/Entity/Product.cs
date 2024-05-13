using System.ComponentModel.DataAnnotations;

namespace EcomShop.Core.src.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The Name field must be between 2 and 100 characters.")]
        [RegularExpression(@"^[A-Za-z]", ErrorMessage = "Name must start with a letter.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Category Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Category Id must be a valid number.")]
        public int CategoryId { get; set; }
        // Navigation property for Order
        public Category? Category { get; set; }


        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price field must be a non-negative number.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Quantity In Stock field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Quantity In Stock field must be a non-negative integer.")]
        public int QuantityInStock { get; set; }

        [StringLength(255, ErrorMessage = "The Image field cannot exceed 255 characters.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The Description field must be between 2 and 100 characters.")]
        public string Description { get; set; }
    }
}
