
namespace EcomShop.Application.src.DTO
{
    public class ProductImageCreateDto
    {
        public Guid productId { get; set; }
        public string Url { get; set; } = string.Empty;
    }
    public class ProductImageReadDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? Url { get; set; }

    }
    public class ProductImageUpdateDto
    {
        public string Url { get; set; }

    }
}