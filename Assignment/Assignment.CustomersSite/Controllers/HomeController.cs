using Assignment.CustomersSite.Models;
using Assignment.CustomersSite.Service;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Diagnostics;

namespace Assignment.CustomersSite.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ICategory _category;
        private HomeModel _home;
        public HomeController()
        {
            _category = RestService.For<ICategory>("https://localhost:5445");
            _home = new HomeModel();
        }

        public async Task<IActionResult> Index()
        {
            var categories = _category.GetAllCategory().GetAwaiter().GetResult();
            _home.Categories = categories;
            return View(_home);
        }
    }
}