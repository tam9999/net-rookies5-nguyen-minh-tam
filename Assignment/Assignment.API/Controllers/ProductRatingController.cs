using Assignment.API.Interfaces;
using Assignment.SharedViewModels.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var feedbacks = await productRatingService.GetProductRatingByProductIdAsync(Id);
            if (feedbacks == null)
            {
                return NotFound("Comment can't be found");
            }
            return Ok(feedbacks);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProductRatingAsync([FromBody] ProductRatingCreateRequest request)
        {
            var reviewId = await productRatingService.CreateProductRatingAsync(request);
            if (reviewId == 0)
            {
                return BadRequest();
            }
            //var review = await productRatingService.GetProductRatingByIdAsync(reviewId);
            //if (review == null)
            //{
            //    return BadRequest();
            //}
            return Ok(reviewId);
        }
    }
}
