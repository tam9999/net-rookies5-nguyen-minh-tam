using Assignment.API.Interfaces;
using Assignment.SharedViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRatingController: Controller
    {
        IProductRating productRatingService;
        public ProductRatingController(IProductRating _productRatingService)
        {
            this.productRatingService = _productRatingService;
        }

        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductRatingByProductIdAsync([FromRoute] int Id)
        {
            try
            {
                var feedbacks = await productRatingService.GetProductRatingByProductIdAsync(Id);
                if (feedbacks == null)
                {
                    return NotFound("Comment can't be found");
                }
                return Ok(feedbacks);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProductRatingAsync([FromBody] ProductRatingCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var reviewId = await productRatingService.CreateProductRatingAsync(request);
                if (reviewId == 0)
                {
                    return BadRequest();
                }

                return Ok(reviewId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
