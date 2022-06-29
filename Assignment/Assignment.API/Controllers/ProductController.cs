using Assignment.API.Interfaces;
using Assignment.Domain.Entities;
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
