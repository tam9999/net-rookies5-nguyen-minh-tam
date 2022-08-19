using Assignment.API.Interfaces;
using Assignment.API.Services;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IProductService productService;
        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }

        [HttpGet]
        [Route("GetAllProduct/{page}/{pageSize}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAllProductAsync(int? page, int? pageSize)
        {
            var products = await productService.GetAllProductAsync(page, pageSize);
            if (products == null) return BadRequest();
            return Ok(products);

        }

        [HttpGet("Top8")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetTop8Async()
        {
            //var products = _context.Products.ToList();
            var products = await productService.GetTop8Async();
            return Ok(products);
        }

        [HttpGet("Search/{productName}")]
        //[AllowAnonymous]
        //[Route("Search")]
        public async Task<IActionResult> SearchByNameAsync([FromRoute] string productName)
        {
            try
            {
                var data = await productService.SearchByNameAsync(productName);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductByIdAsync(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var product = await productService.GetProductByIdAsync(Id);

                if (product == null)
                {
                    return NotFound($"Cannot find a product with Id: {Id}");
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{productId}")]
        [AllowAnonymous]
        //[Route("GetProductDetail")]
        public async Task<IActionResult> GetProductDetailAsync(int? productId)
        {
            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                var productDetail = await productService.GetProductDetailAsync(productId);

                if (productDetail == null)
                {
                    return NotFound($"Cannot find a product with Id: {productId}");
                }

                return Ok(productDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddProductAsync([FromForm] ProductCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var productId = await productService.AddProductAsync(request);
                if (productId == null)
                {
                    return BadRequest();
                }
                var result = await productService.GetProductByIdAsync(productId);
                if (result == null)
                {
                    return NotFound($"Cannot find a product with Id: {productId}");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProductAsync(int? productId)
        {
            int result = 0;

            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await productService.DeleteProductAsync(productId);
                if (result == 0)
                {
                    return NotFound($"Cannot find a cake with Id: {productId}");
                }
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await productService.UpdateProductAsync(request);
                if (result == 0)
                {
                    return BadRequest();
                }
                var data = await productService.GetProductByIdAsync(request.Id);
                if (data == null)
                {
                    return NotFound($"Cannot find a product with Id: {request.Id}");
                }
                return Ok(JsonConvert.SerializeObject(data));
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
