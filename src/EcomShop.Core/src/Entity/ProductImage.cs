using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomShop.Core.src.Entity
{
    public class ProductImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Product Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Product Id must be a valid number.")]
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        [Required(ErrorMessage = "The URL field is required.")]
        [Url(ErrorMessage = "Invalid URL format.")]
        public string? Url { get; set; }

        public ProductImage(Guid productId, string url)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Url = url;
        }
        public void UpdateUrl(string newUrl)
        {
            Url = newUrl;
        }
    }
}