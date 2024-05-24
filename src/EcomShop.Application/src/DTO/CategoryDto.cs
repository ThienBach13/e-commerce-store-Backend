using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class CategoryCreateDto
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
    }
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }

        public void Transform(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Image = category.Image;
        }
    }

    public class CategoryUpdateDto
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
    }


}