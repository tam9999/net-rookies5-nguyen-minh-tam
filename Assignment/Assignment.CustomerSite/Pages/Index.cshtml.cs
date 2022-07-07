using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Assignment.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategory _category;
        private readonly IProduct _product;
        //private readonly IProductViewModel _productViewModel;
        //private readonly ICategoryViewModel _categoryViewModel;
        public HomeViewModel _home;
        //public CategoryViewModel = new List<CategoryViewModel>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _category = RestService.For<ICategory>("https://localhost:5445");
            _product = RestService.For<IProduct>("https://localhost:5445");
            //_productViewModel = RestService.For<IProductViewModel>("https://localhost:5445");
            //_categoryViewModel = RestService.For<ICategory>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var categories = _category.GetAllCategoryAsync().GetAwaiter().GetResult();
            var products = _product.GetAllProduct().GetAwaiter().GetResult();
            //var productViewModel = _productViewModel.GetProductDetail(Id).GetAwaiter().GetResult();
            var categoryList = new List<CategoryViewModel>();
            //foreach (var category in categories)
            //{
            //    var categoryDetail = _category.GetCategoryDetail(category.Id).GetAwaiter().GetResult();
            //    categoryList.Add(categoryDetail);
            //}
            _home.Categories = categories;
            _home.Products = products;
            //_home.ProductDetail = productViewModel;
            //_home.CategoryDetail = categoryViewModel;
            return Page();
            
            
        }
        //public async Task<IActionResult> ProductDetail(int Id)
        //{
        //    var productViewModel = _productViewModel.GetProductDetail(Id).GetAwaiter().GetResult();
        //    _home.ProductDetail = productViewModel;
        //    return Page();
        //}
    }
}