using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Category CreateCategory(CategoryCreateDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Image = categoryDto.Image
            };
        }
        public void Transform(Category category)
        {
            Name = category.Name;
            Description = category.Description;
            Image = category.Image;
        }
    }
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public void Transform(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Description = category.Description;
            Image = category.Image;
        }

        public static IEnumerable<CategoryReadDto> ConvertList(IEnumerable<Category> categories)
        {
            var categoryReadDtos = new List<CategoryReadDto>();

            foreach (var category in categories)
            {
                var categoryReadDto = new CategoryReadDto();
                categoryReadDto.Transform(category);
                categoryReadDtos.Add(categoryReadDto);
            }

            return categoryReadDtos;
        }
    }

    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Category UpdateCategory(Category oldCategory)
        {
            oldCategory.Name = Name;
            oldCategory.Description = Description;
            oldCategory.Image = Image;
            return oldCategory;
        }

    }


}