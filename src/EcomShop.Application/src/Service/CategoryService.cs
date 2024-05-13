using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;



namespace EcomShop.Application.src.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        // constructor
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryReadDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return CategoryReadDto.ConvertList(categories);
        }

        public async Task<CategoryReadDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            var categoryDto = new CategoryReadDto();
            categoryDto.Transform(category);
            return categoryDto;
        }
        public async Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            var category = categoryDto.CreateCategory(categoryDto);

            var createdCategory = await _categoryRepository.CreateCategoryAsync(category);
            var categoryReadDto = new CategoryReadDto();

            categoryReadDto.Transform(createdCategory);
            return categoryReadDto;
        }
        public async Task<bool> UpdateCategoryByIdAsync(CategoryUpdateDto categoryDto)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(categoryDto.Id);
            if (existingCategory == null)
                return false;

            existingCategory = categoryDto.UpdateCategory(existingCategory);

            
            return await _categoryRepository.UpdateCategoryAsync(existingCategory) != null;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryByIdAsync(id);
        }

    }
}