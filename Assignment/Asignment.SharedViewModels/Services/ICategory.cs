using Assignment.Domain.Entities;
using Refit;

namespace Asignment.SharedViewModels.Services
{
    public interface ICategory
    {
        [Get("/api/Categories/GetAllCategory")] 
        Task<List<Category>> GetAllCategory();
    }
}
