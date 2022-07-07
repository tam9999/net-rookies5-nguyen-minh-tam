using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface ICategory
    {
        [Get("/api/Categories/GetAllCategory")] 
        Task<List<Category>> GetAllCategoryAsync();

        [Get("/api/Categories/ProductByCategory")]
        Task<List<CategoryViewModel>> GetCategoryDetailAsync();
    }
}
