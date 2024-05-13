using System.ComponentModel.DataAnnotations;

namespace EcomShop.Core.src.Entity
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The Name field must be between 2 and 100 characters.")]
        [RegularExpression(@"^[A-Za-z]", ErrorMessage = "Name must start with a letter.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "The Description field cannot exceed 255 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Url field is required.")]
        [StringLength(255, ErrorMessage = "The Url field cannot exceed 255 characters.")]
        [Url(ErrorMessage = "The Url field must be a valid URL.")]
        public string Url { get; set; }
    }
}