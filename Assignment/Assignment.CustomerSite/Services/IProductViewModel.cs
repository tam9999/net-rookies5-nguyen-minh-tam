using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface IProductViewModel
    {
        
        //[Get("api/Product/Top8")]
        //Task<ProductViewModel> GetTop8Async();

        [Get("/api/Product/GetProductDetail/")]
        Task<ProductViewModel> GetProductDetail(int productId);

        //[Get("api/Product/Search/{productName}")]
        //Task<SearchProductViewModel> SearchByName();
    }
}
