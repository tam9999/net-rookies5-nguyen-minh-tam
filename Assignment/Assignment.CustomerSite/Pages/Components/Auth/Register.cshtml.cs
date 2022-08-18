using Assignment.API.Requests;
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
        private readonly IUser _user;
        public HomeViewModel _home;

        public RegisterModel(ILogger<RegisterModel> logger)
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
        [BindProperty]
        public string ConfirmPassword { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public DateTime CreatedDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int productId)
        {
            var categories = _category.GetAllCategoryAsync().GetAwaiter().GetResult();
            _home.Categories = categories;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(SignupRequest request)
        { 
                request.Email = Email;
                request.Password = Password;
                request.ConfirmPassword = ConfirmPassword;
                request.FirstName = FirstName;
                request.LastName = LastName;
                request.Phone = Phone;
                request.Address = Address;
                request.CreatedDate = DateTime.Now;
                var register = await _user.SignupAsync(request);
                _home.Register = register.Email;
                return RedirectToPage("Login");      
        }
    }
}
