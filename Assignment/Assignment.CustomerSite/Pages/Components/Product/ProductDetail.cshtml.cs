using Assignment.CustomerSite.Models;
using Assignment.CustomerSite.Services;
using Assignment.SharedViewModels.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace Assignment.CustomerSite.Pages.Components.Product
{
    public class ProductDetailModel : PageModel
    {

        private readonly ILogger<ProductDetailModel> _logger;
        private readonly IProduct _product;
        private readonly ICategory _category;
        private readonly IProductRating _productRating;
        public HomeViewModel _home;

        public ProductDetailModel(ILogger<ProductDetailModel> logger)
        {
            _logger = logger;
            _product = RestService.For<IProduct>("https://localhost:5445");
            _category = RestService.For<ICategory>("https://localhost:5445");
            _productRating = RestService.For<IProductRating>("https://localhost:5445");
            _home = new HomeViewModel();
        }

        public async Task<IActionResult> OnGetAsync(int productId)
        {
            var categories = _category.GetAllCategoryAsync().GetAwaiter().GetResult();
            var products = _product.GetAllProductAsync().GetAwaiter().GetResult();
            var productViewModel = await _product.GetProductDetailAsync(productId);
            var comment = await _productRating.GetProductRatingByIdAsync(productId);

            _home.Comments = comment;
            _home.Categories = categories;
            _home.Products = products;
            _home.ProductDetail = productViewModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(RatingCreateRequest request)
        {
            request.CreatedDate = DateTime.Now;
            request.UserId = 2;
            request.UserName = "Nguyen Minh Tam";
            //request.ProductId = id;
            await _productRating.CreateProductRatingAsync(request);
            
            return Page();
            //return RedirectToAction("./Index");
        }

    }
}
