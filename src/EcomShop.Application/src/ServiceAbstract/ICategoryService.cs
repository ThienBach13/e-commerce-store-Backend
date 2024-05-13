using EcomShop.Application.src.DTO;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> GetAllCategoriesAsync();
        Task<CategoryReadDto> GetCategoryByIdAsync(int categoryId);
        Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto category);
        Task<bool> UpdateCategoryByIdAsync(CategoryUpdateDto category);
        Task<bool> DeleteCategoryByIdAsync(int id);
    }
}