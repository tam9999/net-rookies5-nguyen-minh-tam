using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;

namespace Assignment.API.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryAsync(int? categoryId);
        Task<int> AddCategoryAsync(CategoryCreateRequest request);
        Task<int> DeleteCategoryAsync(int? categoryId);
        Task<int> UpdateCategoryAsync(CategoryUpdateRequest request);
        Task<List<CategoryViewModel>> GetCategoryDetailAsync(int? categoryId);
        
    }
}
