
namespace EcomShop.Application.src.DTO
{
    public class OrderedLineItemCreateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderedLineItemReadDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class OrderedLineItemUpdateDto
    {
        public Guid ItemId { get; set; }
        public int? Quantity { get; set; }
    }
}