using Assignment.API.Requests;
using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Auth
{
    
    public class LogoutModel : PageModel
    {
        private readonly ILogger<LogoutModel> _logger;
        private readonly ICategory _category;
        private readonly IUser _user;
        public HomeViewModel _home;

        public LogoutModel(ILogger<LogoutModel> logger)
        {
            _logger = logger;
            _user = RestService.For<IUser>("https://localhost:5445");
            _home = new HomeViewModel();
        }
       
        [BindProperty]
        public int userId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync(int userId)
        {  
            var logout = await _user.LogoutAsync(userId);      
            _home.Logout = logout;
            //return RedirectToPage("../Index");
            return Page();
        }
    }
}
