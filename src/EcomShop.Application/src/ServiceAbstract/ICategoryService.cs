using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface ICategoryService : IBaseService<CategoryReadDto, CategoryCreateDto, CategoryUpdateDto, QueryOptions>
    {
        Task<CategoryReadDto> UpdateCategoryNameAsync(Guid categoryId, string updatedName);
        Task<CategoryReadDto> UpdateCategoryImageAsync(Guid categoryId, string UpdatedImage);
    }
}