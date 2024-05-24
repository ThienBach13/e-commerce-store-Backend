using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcomShop.Core.src.Entity
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(225, MinimumLength = 2, ErrorMessage = "The Name must be between 2 and 225 characters.")]
        public string? Name { get; set; }

        [Url(ErrorMessage = "The Image URL is not valid.")]
        public string? Image { get; set; } = string.Empty;
        public IEnumerable<Product>? Products { get; set; }

        public Category(string name, string image)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
        }
        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateImage(string image)
        {
            Image = image;
        }
        public override string ToString()
        {
            return $"Category: Id={Id}, Name={Name}, Image={Image}";
        }
    }
}