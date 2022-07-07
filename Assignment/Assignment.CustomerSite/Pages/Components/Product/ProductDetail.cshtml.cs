using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Product
{
    public class ProductDetailModel : PageModel
    {

        private readonly ILogger<ProductDetailModel> _logger;
        private readonly ICategory _category;
        private readonly IProduct _product;
        //private readonly IProductViewModel _productViewModel;
        public HomeViewModel _home;

        public ProductDetailModel(ILogger<ProductDetailModel> logger)
        {
            _logger = logger;
            //_category = RestService.For<ICategory>("https://localhost:5445");
            _product = RestService.For<IProduct>("https://localhost:5445");
            //_productViewModel = RestService.For<IProductViewModel> ("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            //var categories = _category.GetAllCategory().GetAwaiter().GetResult();
            //var products = _product.GetAllProduct().GetAwaiter().GetResult();
            //var productViewModel = _product.GetProductDetail(Id).GetAwaiter().GetResult();
            ////_home.Categories = categories;
            //_home.Products = products;
            //_home.ProductDetail = productViewModel;

            return Page();
        }
        //public async Task<IActionResult> OnGet(int Id)
        //{
        //    var productViewModel = _productViewModel.GetProductDetail(Id).GetAwaiter().GetResult();
        //    _home.ProductDetail = productViewModel;
        //    return Page();
        //}
    }
}
