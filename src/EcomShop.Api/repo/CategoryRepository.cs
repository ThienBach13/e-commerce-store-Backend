using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcomShopDbContext _dbContext;

        public CategoryRepository(EcomShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            // var categoryDto = new CategoryCreateDto();
            // categoryDto.Transform(category);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if (category is null)
            {
                return false;
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var existingCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                throw new InvalidOperationException($"Category with ID {category.Id} not found.");
            }
            // _dbContext.Categories.Update(category);
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.Image = category.Image;
            await _dbContext.SaveChangesAsync();

            return category;
        }
    }
}