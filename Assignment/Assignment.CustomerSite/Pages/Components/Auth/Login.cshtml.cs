using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Auth
{
    public class LoginModel : PageModel
    {
        
        private readonly ILogger<LoginModel> _logger;
        private readonly ICategory _category;
        public HomeViewModel _home;

        public LoginModel(ILogger<LoginModel> logger)
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
