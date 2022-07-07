using Assignment.API.Interfaces;
using Assignment.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Route("GetAllProduct")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAllProductAsync()
        {
            try
            {
                var product = await productService.GetAllProductAsync();
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

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
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
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
                    return NotFound();
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
        public async Task<IActionResult> AddProductAsync([FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productId = await productService.AddProductAsync(model);
                    if (productId > 0)
                    {
                        return Ok(productId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
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
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.UpdateProductAsync(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
