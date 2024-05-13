using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public static Product CreateProduct(ProductCreateDto product)
        {
            return new Product
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                Image = product.Image,
                Description = product.Description
            };
        }
    }

    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public void Transform(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            CategoryId = product.CategoryId;
            Price = product.Price;
            QuantityInStock = product.QuantityInStock;
            Image = product.Image;
            Description = product.Description;
        }

        public static IEnumerable<ProductReadDto> ConvertList(IEnumerable<Product> products)
        {
            var productReadDtos = new List<ProductReadDto>();

            foreach (var product in products)
            {
                var productReadDto = new ProductReadDto();
                productReadDto.Transform(product);
                productReadDtos.Add(productReadDto);
            }

            return productReadDtos;
        }
    }

    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public Product UpdateProduct(Product oldProduct)
        {
            oldProduct.Name = Name;
            oldProduct.CategoryId = CategoryId;
            oldProduct.Price = Price;
            oldProduct.QuantityInStock = QuantityInStock;
            oldProduct.Image = Image;
            oldProduct.Description = Description;
            return oldProduct;
        }
    }
}
