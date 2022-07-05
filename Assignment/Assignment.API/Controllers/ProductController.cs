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
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var product = await productService.GetAllProduct();
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
        public async Task<IActionResult> GetTop8()
        {
            //var products = _context.Products.ToList();
            var products = await productService.GetTop8Async();
            return Ok(products);
        }

        [HttpGet("Search/{productName}")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchByName([FromRoute] string productName)
        {
            try
            {
                var data = await productService.SearchByName(productName);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct(int? productId)
        {
            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                var product = await productService.GetProduct(productId);

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

        [HttpGet]
        [Route("GetProductDetail")]
        public async Task<IActionResult> GetProductDetail(int? productId)
        {
            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                var productDetail = await productService.GetProductDetail(productId);

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
        public async Task<IActionResult> AddProduct([FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var productId = await productService.AddProduct(model);
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
        public async Task<IActionResult> DeleteProduct(int? productId)
        {
            int result = 0;

            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await productService.DeleteProduct(productId);
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
        public async Task<IActionResult> UpdateProduct([FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await productService.UpdateProduct(model);

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
