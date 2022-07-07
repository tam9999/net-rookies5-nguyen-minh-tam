using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface IProduct
    {
        [Get("/api/Product/GetAllProduct")]
        Task<List<Product>> GetAllProductAsync();

        [Get("/api/Product/{productId}")]
        Task<ProductViewModel> GetProductDetail(int productId);
    }
}
