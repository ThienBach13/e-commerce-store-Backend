using System.ComponentModel.DataAnnotations;

namespace EcomShop.Core.src.Entity
{
    public class OrderedLineItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Order Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Order Id must be a valid number.")]
        public int OrderId { get; set; }
        // Navigation property for Order
        public Order? Order { get; set; }

        [Required(ErrorMessage = "The Product Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Product Id must be a valid number.")]
        public int ProductId { get; set; }
        // Navigation property for Product
        public Product? Product { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price field must be a non-negative number.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        [Range(1, 50, ErrorMessage = "The Quantity field must be a value between 1 and 50.")]
        public int Quantity { get; set; }
    }
}