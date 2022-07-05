using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;

namespace Assignment.API.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProduct(int? productId);
        Task<int> AddProduct(Product product);
        Task<int> DeleteProduct(int? productId);
        Task UpdateProduct(Product product);
        Task<ProductViewModel> GetProductDetail(int? productId);
        Task<List<SearchProductViewModel>> SearchByName(string productName);
        Task<List<ProductViewModel>> GetTop8Async();
        
    }
}
