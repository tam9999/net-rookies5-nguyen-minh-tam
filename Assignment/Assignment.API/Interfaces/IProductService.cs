using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Dtos;
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
        Task<ProductDto> GetAllProductAsync(int? page, int? pageSize);

        Task<ProductViewModel> GetProductDetailAsync(int? productId);

        Task<ProductViewModel> GetProductByIdAsync(int? productId);
        Task<int> UpdateProductAsync(ProductUpdateRequest request);
    }
}
