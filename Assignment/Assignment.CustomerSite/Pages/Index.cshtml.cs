using Assignment.API.Requests;
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
        //private readonly IUser _user;
        public HomeViewModel _home;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _category = RestService.For<ICategory>("https://localhost:5445");
            _product = RestService.For<IProduct>("https://localhost:5445");
            //_user = RestService.For<IUser>("https://localhost:5445");
            _home = new HomeViewModel();
        }
        public int TotalItem { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public double NumberPage { get; set; }
        public int? PageSize { get; set; } = 4;
        //[BindProperty]
        //public string Email { get; set; }
        //[BindProperty]
        //public string Password { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var categories =  await _category.GetAllCategoryAsync();
            var products = await _product.GetAllProductAsync(CurrentPage, PageSize);
            _home.Products = products;
            _home.Categories = categories;
            return Page();
            
        }

        //public async Task<IActionResult> OnPostAsync(LoginRequest request)
        //{
        //    request.Email = Email;
        //    request.Password = Password;
        //    var login = await _user.LoginAsync(request);
        //    _home.user = login;
        //    return Page();
        //}
    }
}