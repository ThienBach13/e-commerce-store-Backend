using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomShop.Core.src.Entity
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The User Id field is required.")]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [Required(ErrorMessage = "The Create at field is required.")]
        [DataType(DataType.Date, ErrorMessage = "Order Date must be in a valid date format.")]
        public DateTime CreatedAt { get; set; }
        public IReadOnlyCollection<OrderedLineItem>? OrderItems;
    }
}