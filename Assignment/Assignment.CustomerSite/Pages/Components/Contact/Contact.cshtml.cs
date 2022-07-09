
using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Contact
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;
        private readonly ICategory _category;
        public HomeViewModel _home;

        public ContactModel(ILogger<ContactModel> logger)
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
