using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Product
{
    public class SearchModel : PageModel
    {
        private readonly ILogger<SearchModel> _logger;
        private readonly IProduct _product;
        private readonly ICategory _category;
        public HomeViewModel _home;

        public SearchModel(ILogger<SearchModel> logger)
        {
            _logger = logger;
            _product = RestService.For<IProduct>("https://localhost:5445");
            _category = RestService.For<ICategory>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        [BindProperty]
        public int TotalItem { get; set; }
        [BindProperty]
        public int CurrentPage { get; set; } = 1;
        [BindProperty]
        public double NumberPage { get; set; }
        [BindProperty]
        public int? PageSize { get; set; } = 4;

        public async Task<IActionResult> OnGetAsync(string productName)
        {
            var categories = _category.GetAllCategoryAsync().GetAwaiter().GetResult();
            var products = _product.GetAllProductAsync(CurrentPage, PageSize).GetAwaiter().GetResult();
            //var productViewModel = await _product.GetProductDetailAsync(productId);
            var searchViewModel = await _product.SearchByNameAsync(productName);
            _home.Categories = categories;
            _home.Products = products;
            _home.SearchProducts = searchViewModel;
            
            return Page();
        }
    }
}
