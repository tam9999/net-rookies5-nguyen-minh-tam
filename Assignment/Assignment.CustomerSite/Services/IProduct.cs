using Assignment.Domain.Entities;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface IProduct
    {
        [Get("/api/Product/GetAllProduct")]
        Task<List<Product>> GetAllProduct();
    }
}
