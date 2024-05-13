using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShop.Core.src.Entity
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Shopping Cart Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Shopping Cart Id must be a valid number.")]
        public int ShoppingCartId { get; set; }

        [Required(ErrorMessage = "The ProductId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Product Id must be a valid number.")]
        public int ProductId { get; set; }
        // Navigation property for Product
        public Product Product { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        [Range(1, 50, ErrorMessage = "The Quantity field must be a value between 1 and 50.")]
        public int Quantity { get; set; }
    }
}