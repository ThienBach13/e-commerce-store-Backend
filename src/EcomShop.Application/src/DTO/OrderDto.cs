using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class OrderCreateDto
    {
        public Guid UserId { get; set; }
        public List<OrderedLineItemCreateDto> Items { get; set; } = new List<OrderedLineItemCreateDto>();
    }

    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderedLineItemReadDto>? OrderItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }

    public class OrderUpdateDto
    {
        public List<OrderedLineItemUpdateDto>? UpdatedItems { get; set; }
    }
}