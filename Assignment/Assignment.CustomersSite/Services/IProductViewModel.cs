using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomersSite.Services
{
    public interface IProductViewModel
    {
        [Get("/api/Product/GetProduct")]
        Task<ProductViewModel> GetProduct();
    }
}
