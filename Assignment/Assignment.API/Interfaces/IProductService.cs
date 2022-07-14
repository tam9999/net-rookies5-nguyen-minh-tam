using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;

namespace Assignment.API.Interfaces
{
    public interface IProductService
    {
        Task<List<SearchProductViewModel>> SearchByNameAsync(string productName);
        Task<List<ProductViewModel>> GetTop8Async();
        Task<int> DeleteProductAsync(int? productId);

        
        Task<int> AddProductAsync(ProductCreateRequest request);
        Task<List<ProductViewModel>> GetAllProductAsync();
        
        Task<ProductViewModel> GetProductDetailAsync(int? Id);
        
        Task<ProductViewModel> GetProductByIdAsync(int? productId);
        Task<int> UpdateProductAsync(ProductUpdateRequest request);
    }
}
