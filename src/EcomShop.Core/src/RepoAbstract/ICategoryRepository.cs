using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryByIdAsync(int id);
        // Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int id);
    }
}