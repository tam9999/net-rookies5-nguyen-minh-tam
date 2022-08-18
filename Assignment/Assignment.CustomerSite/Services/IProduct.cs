using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Dtos;
using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface IProduct
    {
        [Get("/api/Product/GetAllProduct/{page}/{pageSize}")]
        Task<ProductDto> GetAllProductAsync(int? page, int? pageSize);

        [Get("/api/Product/{productId}")]
        Task<ProductViewModel> GetProductDetailAsync(int productId);

        [Get("/api/Product/Search/{productName}")]
        Task<List<SearchProductViewModel>> SearchByNameAsync(string productName);

    }
}
