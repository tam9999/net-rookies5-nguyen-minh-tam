using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;

namespace Assignment.API.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategories(int? categoryId);
        Task<int> AddCategory(Category category);
        Task<int> DeleteCategory(int? CategoryId);
        Task UpdateCategory(Category category);
        Task<List<CategoryViewModel>> GetCategoryDetail(int? categoryId);
        
    }
}
