using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;



namespace EcomShop.Application.src.Service
{
    public class CategoryService : BaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto, QueryOptions>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryReadDto> UpdateCategoryImageAsync(Guid categoryId, string UpdatedImage)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId) ?? throw new KeyNotFoundException("Category not found");
            category.UpdateImage(UpdatedImage);
            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryReadDto>(category);
        }

        public async Task<CategoryReadDto> UpdateCategoryNameAsync(Guid categoryId, string updatedName)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId) ?? throw new KeyNotFoundException("Category not found");
            category.UpdateName(updatedName);
            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryReadDto>(category);
        }
    }
}