using Assignment.Domain.Entities;
using Refit;

namespace Asignment.CustomersSite.Services
{
    public interface ICategory
    {
        [Get("/api/Categories/GetAllCategory")] 
        Task<List<Category>> GetAllCategory();
    }
}
