using Assignment.Domain.Entities;
using Refit;

namespace Asignment.CustomersSite.Services
{
    public interface IProduct
    {
        [Get("/api/Product/GetAllProduct")]
        Task<List<Product>> GetAllProduct();
    }
}
