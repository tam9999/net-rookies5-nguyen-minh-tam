using Assignment.API.Requests;
using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;
using System.Security.Claims;

namespace Assignment.CustomerSite.Pages.Components.Auth
{
    public class LoginModel : PageModel
    {
        
        private readonly ILogger<LoginModel> _logger;
        private readonly ICategory _category;
        private readonly IUser _user;
        public HomeViewModel _home;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
            _category = RestService.For<ICategory>("https://localhost:5445");
            _user = RestService.For<IUser>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public async Task<IActionResult> OnGetAsync(int productId)
        {
            var categories = await _category.GetAllCategoryAsync();
            _home.Categories = categories;
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(LoginRequest request)
        {
            request.Email = Email;
            request.Password = Password;
            var login = await _user.LoginAsync(request);
            _home.user = login;
            //return RedirectToPage("./Index");
            return Page();
        }
    }
}
