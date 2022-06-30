using Assignment.Domain.Entities;
using Refit;

namespace Assignment.CustomersSite.Service
{
    public interface ICategory
    {
        [Get("/api/Categories/GetAllCategory")]
        Task<List<Category>> GetAllCategory();
    }
}
