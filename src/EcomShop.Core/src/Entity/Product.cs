using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomShop.Core.src.Entity
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(225, MinimumLength = 2, ErrorMessage = "The Name field must be between 2 and 225 characters.")]
        [RegularExpression(@"^[A-Za-z]", ErrorMessage = "Name must start with a letter.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(225, MinimumLength = 2, ErrorMessage = "The Description field must be between 2 and 225 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price field must be a non-negative number.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Category Id field is required.")]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        [StringLength(255, ErrorMessage = "The Image field cannot exceed 255 characters.")]
        public ICollection<ProductImage>? Images { get; set; }

        public Product(string name, decimal price, string description, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Description = description;
            CategoryId = categoryId;
        }

        public void UpdateDetails(string? name = null, decimal? price = null, string? description = null)
        {
            if (name != null)
            {
                Name = name;
            }

            if (price != null)
            {
                Price = price.Value;
            }

            if (description != null)
            {
                Description = description;
            }
        }

        public void UpdateCategory(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public void SetProductImages(ICollection<ProductImage> images)
        {
            Images = images;
        }
    }
}
