using Microsoft.AspNetCore.Mvc;
using Refit;
using Assignment.CustomersSite.Services;
using Asignment.CustomersSite.Services;
using Asignment.CustomersSite.Models;

namespace Assignment.CustomersSite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ICategory _category;
        private readonly IProduct _product;
        //private readonly IProductViewModel _productViewModel;
        private HomeViewModel _home;
        public HomeController()
        {
            _category = RestService.For<ICategory>("https://localhost:5445");
            _product = RestService.For<IProduct>("https://localhost:5445");
            //_productViewModel = RestService.For<IProductViewModel>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> Index()
        {
            var categories = _category.GetAllCategory().GetAwaiter().GetResult();
            var products = _product.GetAllProduct().GetAwaiter().GetResult();
            //var productViewModel = _productViewModel.GetProduct().GetAwaiter().GetResult();
            _home.Categories = categories;
            _home.Products = products;
            //_home.Product = productViewModel;
            return View(_home);
        }
    }
}