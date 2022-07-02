using Asignment.CustomersSite.Services;
using Asignment.CustomersSite.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Assignment.CustomersSite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ICategory _category;
        private readonly IProduct _product;
        private HomeViewModel _home;
        public HomeController()
        {
            _category = RestService.For<ICategory>("https://localhost:5445");
            _product = RestService.For<IProduct>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> Index()
        {
            var categories = _category.GetAllCategory().GetAwaiter().GetResult();
            var products = _product.GetAllProduct().GetAwaiter().GetResult();   
            _home.Categories = categories;
            _home.Products = products;
            return View(_home);
        }
    }
}