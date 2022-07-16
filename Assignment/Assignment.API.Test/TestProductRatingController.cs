using Assignment.API.Controllers;
using Assignment.API.Test.Mocks;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Test
{
    public class TestProductRatingController
    {
        //Get Product Rating
        //[Fact]
        //public async void GetProductRatingByProductIdAsync_ReturnsOk()
        //{
        //    var mockData = new ProductRatingViewModel()
        //    {
        //        Id = 1,
        //        UserId = 1,
        //        UserName = "Nguyen Minh Tam",
        //        ProductId = 1,
        //        Comment = "Ngonnnnn",
        //        Star = 5,
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = DateTime.Now,
        //    };
        //    var mockReviewService = new MockProductRating().MockGetProductRatingByProductIdAsync(mockData);
        //    var controller = new ProductRatingController( mockReviewService.Object);

        //    var result = await controller.GetProductRatingByProductIdAsync(1) as OkObjectResult;

        //    Assert.IsType<OkObjectResult>(result);
        //    Assert.Equal(200, result.StatusCode);
        //}

        [Fact]
        public async void GetProductRatingByProductIdAsync_ReturnsBadRequest()
        {
            var mockReviewService = new MockProductRating().MockGetProductRatingByProductIdAsync_ThrowException();
            var controller = new ProductRatingController(mockReviewService.Object);

            var result = await controller.GetProductRatingByProductIdAsync(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void GetReviewByCakeId_ReturnsBadRequest()
        {
            var mockReviewService = new MockProductRating().MockGetProductRatingByProductIdAsync_ThrowException();
            var controller = new ProductRatingController(mockReviewService.Object);

            var result = await controller.GetProductRatingByProductIdAsync(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        //Add Product Rating
        [Fact]
        public async void CreateReview_WithValidModel_ReturnsOk()
        {
            var mockReviewService = new MockProductRating().MockCreateProductRatingAsync(1);
            var controller = new ProductRatingController(mockReviewService.Object);

            var result = await controller.CreateProductRatingAsync(new ProductRatingCreateRequest()) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void CreateReview_WithValidModelAndException_ReturnsBadRequest()
        {
            var mockReviewService = new MockProductRating().MockCreateProductRatingAsync_ThrowException();
            var controller = new ProductRatingController(mockReviewService.Object);

            var result = await controller.CreateProductRatingAsync(new ProductRatingCreateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void CreateReview_WithInValidModel_ReturnsBadRequest()
        {
            var mockReviewService = new MockProductRating().MockCreateProductRatingAsync(2);
            var controller = new ProductRatingController(mockReviewService.Object);
            controller.ModelState.AddModelError("Test", "Test");

            var result = await controller.CreateProductRatingAsync(new ProductRatingCreateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
