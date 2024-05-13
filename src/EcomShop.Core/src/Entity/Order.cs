using System.ComponentModel.DataAnnotations;

namespace EcomShop.Core.src.Entity
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The User Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "User Id must be a valid number.")]
        public int UserId { get; set; }
        // Navigation property for User
        public User? User { get; set; }

        [Required(ErrorMessage = "The Order Date field is required.")]
        [DataType(DataType.Date, ErrorMessage = "Order Date must be in a valid date format.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "The Address Id field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Address Id must be a valid number.")]
        public int AddressId { get; set; }

        // Navigation property for Address
        public Address? Address { get; set; }
    }
}