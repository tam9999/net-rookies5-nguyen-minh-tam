using Assignment.Domain.Entities;

namespace Assignment.API.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategories(int? categoryId);
        Task<int> AddCategory(Category category);
        Task<int> DeleteCategory(int? CategoryId);
        Task UpdateCategory(Category category);
    }
}
