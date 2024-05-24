using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomShop.Core.src.Entity
{
    public class OrderedLineItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Order Id field is required.")]
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        [Required(ErrorMessage = "The Product Id field is required.")]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price field must be a non-negative number.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        [Range(1, 50, ErrorMessage = "The Quantity field must be a value between 1 and 50.")]
        public int Quantity { get; set; }
    }
}