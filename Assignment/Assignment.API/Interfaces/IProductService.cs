using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;

namespace Assignment.API.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int? productId);
        Task<int> AddProductAsync(Product product);
        Task<int> DeleteProductAsync(int? productId);
        Task UpdateProductAsync(Product product);
        Task<ProductViewModel> GetProductDetailAsync(int? Id);
        Task<List<SearchProductViewModel>> SearchByNameAsync(string productName);
        Task<List<ProductViewModel>> GetTop8Async();      
    }
}
