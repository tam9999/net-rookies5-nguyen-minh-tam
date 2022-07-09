using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.About
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;
        private readonly ICategory _category;
        public HomeViewModel _home;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
            _category = RestService.For<ICategory>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> OnGetAsync(int productId)
        {
            var categories = _category.GetAllCategoryAsync().GetAwaiter().GetResult();
            _home.Categories = categories;
            return Page();
        }
    }
}