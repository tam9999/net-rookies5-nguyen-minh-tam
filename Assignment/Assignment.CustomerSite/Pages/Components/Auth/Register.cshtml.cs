using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Assignment.SharedViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly ICategory _category;
        //auth
       // private readonly IUser _register;
        public HomeViewModel _home;

        public RegisterModel(ILogger<RegisterModel> logger)
        {
            _logger = logger;
            _category = RestService.For<ICategory>("https://localhost:5445");
            //_register = RestService.For<IUser>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> OnGetAsync(int productId)
        {
            var categories = _category.GetAllCategoryAsync().GetAwaiter().GetResult();
            _home.Categories = categories;
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(RegisterRequestViewModel request)
        //{
        //    request.CreatedDate = DateTime.Now;
        //    await _register.SignupAsync(request);
        //    return Page();
        //}
    }
}
