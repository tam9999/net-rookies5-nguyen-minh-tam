using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;

namespace Assignment.API.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        //Task<Category> GetCategoryAsync(int? categoryId);
        Task<int> AddCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int? categoryId);
        Task UpdateCategoryAsync(Category category);
        Task<List<CategoryViewModel>> GetCategoryDetailAsync(int categoryId);
        
    }
}
