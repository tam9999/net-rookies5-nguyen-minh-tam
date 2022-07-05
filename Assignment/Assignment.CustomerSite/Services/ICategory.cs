using Assignment.Domain.Entities;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface ICategory
    {
        [Get("/api/Categories/GetAllCategory")] 
        Task<List<Category>> GetAllCategory();
    }
}
