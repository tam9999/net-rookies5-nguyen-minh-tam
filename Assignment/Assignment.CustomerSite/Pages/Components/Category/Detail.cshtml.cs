using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Category
{
    public class DetailModel : PageModel
    {
        private readonly ILogger<PageModel> _logger;
        private readonly ICategory _category;
        private readonly IProduct _product;
        //private readonly ICategory _categoryViewModel;
        public HomeViewModel _home;

        public DetailModel(ILogger<PageModel> logger)
        {
            _logger = logger;
            _category = RestService.For<ICategory>("https://localhost:5445");
            //_categoryViewModel = RestService.For<ICategory>("https://localhost:5445");
            _product = RestService.For<IProduct>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> OnGetAsync(int categoryId)
        {
            var categories = _category.GetAllCategoryAsync().GetAwaiter().GetResult();
            var categoryViewModel = await _category.GetCategoryDetailAsync(categoryId);
            var products = _product.GetAllProductAsync().GetAwaiter().GetResult();
            _home.Products = products;
            _home.Categories = categories;
            _home.CategoryDetail = categoryViewModel;
            return Page();
        }
    }
}
