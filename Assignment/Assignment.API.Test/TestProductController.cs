
using Assignment.API.Controllers;
using Assignment.API.Interfaces;
using Assignment.API.Test.Mocks;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace Assignment.API.Test
{
    public class TestProductController
    {
        public Mock<IProductService> _mockProductService = new Mock<IProductService>();
        //Get All Product
        //[Fact]
        //public async void Get_ReturnsOk()
        //{
            
        //    var Items = new List<ProductViewModel>()
        //    {
        //        new ProductViewModel()
        //        {
        //            Id = 1,
        //            Name = "Gạo Lứt Tẻ bao 5kg",
        //            CategoryId = 1,
        //            CategoryName = "Gạo Lứt",
        //            Image = "gao-lut-te.jpg",
        //            Price = 20000,
        //            ProductRatingId = 1,
        //            Start = 5,
        //            Description = "Gạo lứt tẻ thường sẽ khá giống với các loại gạo trắng dùng để nấu cơm hằng ngày, chỉ khác một chút là gạo lứt tẻ sẽ có màu trắng ngà do còn nguyên lớp vỏ cám. Gạo lứt tẻ được chia làm 2 loại là gạo lứt tẻ tròn và gạo lứt tẻ dài.Trước khi nấu gạo lứt, bạn cần ngâm gạo trong vòng 1 - 2 tiếng để hạt gạo được nở ra, như vậy khi mang đi nấu gạo sẽ mềm, dẻo hơn.",
        //            Qty = 100,
        //            CreatedDate = DateTime.Now,
        //            UpdatedDate = DateTime.Now,
        //            ImageId = 0
        //            },
        //        new ProductViewModel()
        //        {
        //            Id = 2,
        //            Name = "Gạo Lứt Nếp bao 1kg",
        //            CategoryId = 1,
        //            CategoryName = "Gạo Lứt",
        //            Image = "gao-lut-nep.jpg",
        //            Price = 20000,
        //            ProductRatingId = 1,
        //            Start = 5,
        //            Description = "Gạo lứt tẻ thường sẽ khá giống với các loại gạo trắng dùng để nấu cơm hằng ngày, chỉ khác một chút là gạo lứt tẻ sẽ có màu trắng ngà do còn nguyên lớp vỏ cám. Gạo lứt tẻ được chia làm 2 loại là gạo lứt tẻ tròn và gạo lứt tẻ dài.Trước khi nấu gạo lứt, bạn cần ngâm gạo trong vòng 1 - 2 tiếng để hạt gạo được nở ra, như vậy khi mang đi nấu gạo sẽ mềm, dẻo hơn.",
        //            Qty = 100,
        //            CreatedDate = DateTime.Now,
        //            UpdatedDate = DateTime.Now,
        //            ImageId = 0
        //        },
        //        new ProductViewModel()
        //        {
        //            Id = 3,
        //            Name = "Gạo Hạt Ngắn bao 2kg",
        //            CategoryId = 2,
        //            CategoryName = "Gạo Thường",
        //            Image = "gao-hat-ngan.jpg",
        //            Price = 20000,
        //            ProductRatingId = 1,
        //            Start = 5,
        //            Description = "Gạo lứt tẻ thường sẽ khá giống với các loại gạo trắng dùng để nấu cơm hằng ngày, chỉ khác một chút là gạo lứt tẻ sẽ có màu trắng ngà do còn nguyên lớp vỏ cám. Gạo lứt tẻ được chia làm 2 loại là gạo lứt tẻ tròn và gạo lứt tẻ dài.Trước khi nấu gạo lứt, bạn cần ngâm gạo trong vòng 1 - 2 tiếng để hạt gạo được nở ra, như vậy khi mang đi nấu gạo sẽ mềm, dẻo hơn.",
        //            Qty = 100,
        //            CreatedDate = DateTime.Now,
        //            UpdatedDate = DateTime.Now,
        //            ImageId = 0
        //        },
        //        new ProductViewModel()
        //        {
        //            Id = 4,
        //            Name = "Tám Xoan Hải Hậu 10kg",
        //            CategoryId = 3,
        //            CategoryName = "Gạo Thơm",
        //            Image = "gao-thom.jpg",
        //            Price = 20000,
        //            ProductRatingId = 1,
        //            Start = 5,
        //            Description = "Gạo lứt tẻ thường sẽ khá giống với các loại gạo trắng dùng để nấu cơm hằng ngày, chỉ khác một chút là gạo lứt tẻ sẽ có màu trắng ngà do còn nguyên lớp vỏ cám. Gạo lứt tẻ được chia làm 2 loại là gạo lứt tẻ tròn và gạo lứt tẻ dài.Trước khi nấu gạo lứt, bạn cần ngâm gạo trong vòng 1 - 2 tiếng để hạt gạo được nở ra, như vậy khi mang đi nấu gạo sẽ mềm, dẻo hơn.",
        //            Qty = 100,
        //            CreatedDate = DateTime.Now,
        //            UpdatedDate = DateTime.Now,
        //            ImageId = 0
        //        },
        //        new ProductViewModel()
        //        {
        //            Id = 5,
        //            Name = "Gạo ST24 bao 5kg",
        //            CategoryId = 1,
        //            CategoryName = "Gạo Thơm",
        //            Image = "gao-lut-te.jpg",
        //            Price = 20000,
        //            ProductRatingId = 1,
        //            Start = 5,
        //            Description = "Gạo lứt tẻ thường sẽ khá giống với các loại gạo trắng dùng để nấu cơm hằng ngày, chỉ khác một chút là gạo lứt tẻ sẽ có màu trắng ngà do còn nguyên lớp vỏ cám. Gạo lứt tẻ được chia làm 2 loại là gạo lứt tẻ tròn và gạo lứt tẻ dài.Trước khi nấu gạo lứt, bạn cần ngâm gạo trong vòng 1 - 2 tiếng để hạt gạo được nở ra, như vậy khi mang đi nấu gạo sẽ mềm, dẻo hơn.",
        //            Qty = 100,
        //            CreatedDate = DateTime.Now,
        //            UpdatedDate = DateTime.Now,
        //            ImageId = 0
        //        }
        //    };

        //    var mockProductService = new MockProductService().MockGetAllProductAsync(Items);

        //    var controller = new ProductController(mockProductService.Object);

        //    OkObjectResult result = await controller.GetAllProductAsync() as OkObjectResult;

        //    Assert.IsType<OkObjectResult>(result);
        //    Assert.Equal(200, result.StatusCode);
        //}

        //[Fact]
        //public async void GetAllProductAsync_ReturnsBadRequest()
        //{
        //    var mockCakeService = new MockProductService().MockGetAllProductAsync_ThrowException();

        //    var controller = new ProductController(mockCakeService.Object);

        //    var result = await controller.GetAllProductAsync();

        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        //[Fact]
        //public async void GetAllProductAsync_WithGetIsNull_ReturnsNotFound()
        //{
        //    var mockCakeService = new MockProductService().MockGetAllProductAsync_ThrowException().MockGetAllProductAsync(null);
        //    var controller = new ProductController(mockCakeService.Object);

        //    var result = await controller.GetAllProductAsync();

        //    Assert.IsType<NotFoundObjectResult>(result);
        //}
        //Get Product By Id
        [Fact]
        public async void GetById_ReturnsOk()
        {
            var mockData = new ProductViewModel()
            {
                Id = 1,
                Name = "Gạo Lứt Tẻ bao 5kg",
                CategoryId = 1,
                CategoryName = "Gạo Lứt",
                Image = "gao-lut-te.jpg",
                Price = 20000,
                ProductRatingId = 1,
                Start = 5,
                Description = "Gạo lứt tẻ thường sẽ khá giống với các loại gạo trắng dùng để nấu cơm hằng ngày, chỉ khác một chút là gạo lứt tẻ sẽ có màu trắng ngà do còn nguyên lớp vỏ cám. Gạo lứt tẻ được chia làm 2 loại là gạo lứt tẻ tròn và gạo lứt tẻ dài.Trước khi nấu gạo lứt, bạn cần ngâm gạo trong vòng 1 - 2 tiếng để hạt gạo được nở ra, như vậy khi mang đi nấu gạo sẽ mềm, dẻo hơn.",
                Qty = 100,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ImageId = 0
            };

            var mockProductService = new MockProductService().MockGetProductByIdAsync(mockData);

            var controller = new ProductController(mockProductService.Object);

            OkObjectResult result = await controller.GetProductByIdAsync(1) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void GetProductByIdAsync_ReturnsBadRequest()
        {
            var mockProductService = new MockProductService().MockGetProductByIdAsync_ThrowException();

            var controller = new ProductController(mockProductService.Object);

            var result = await controller.GetProductByIdAsync(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void GetProductByIdAsync_ReturnsNotFound()
        {
            var mockProductService = new MockProductService().MockGetProductByIdAsync(null);

            var controller = new ProductController(mockProductService.Object);

            var result = await controller.GetProductByIdAsync(1);

            Assert.IsType<NotFoundObjectResult>(result);
        }
        //Add Product
        [Fact]
        public async void Create_WithValidModel_ReturnsOk()
        {
            var mockProductService = new MockProductService().MockAddProductAsync(1).MockGetProductByIdAsync(new ProductViewModel());
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.AddProductAsync(new ProductCreateRequest()) as OkObjectResult;
       
            var okResult = result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void Create_WithValidModelAndException_ReturnsBadRequest()
        {
            var mockProductService = new MockProductService().MockAddProductAsync_ThrowException();
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.AddProductAsync(new ProductCreateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Create_WithInValidModel_ReturnsBadRequest()
        {
            var mockProductService = new MockProductService().MockAddProductAsync(2);
            var controller = new ProductController(mockProductService.Object);
            controller.ModelState.AddModelError("Test", "Test");

            var result = await controller.AddProductAsync(new ProductCreateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Create_WithGetProductByIdIsNull_ReturnsNotFound()
        {
            var mockProductService = new MockProductService().MockAddProductAsync(2).MockGetProductByIdAsync(null);
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.AddProductAsync(new ProductCreateRequest());

            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Update Product
        [Fact]
        public async void Update_WithValidModel_ReturnsOk()
        {
            var mockProductService = new MockProductService().MockUpdateProductAsync(1).MockGetProductByIdAsync(new ProductViewModel());
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.UpdateProductAsync(new ProductUpdateRequest()) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);

            var content = JsonConvert.DeserializeObject<ProductViewModel>(result.Value.ToString());
            Assert.IsType<ProductViewModel>(content);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Update_WithValidModelAndCakeIdIsZero_ReturnsBadRequest()
        {
            var mockProductService = new MockProductService().MockUpdateProductAsync(0);
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.UpdateProductAsync(new ProductUpdateRequest());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Update_WithValidModelAndException_ReturnsBadRequest()
        {
            var mockProductService = new MockProductService().MockUpdateProductAsync_ThrowException();
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.UpdateProductAsync(new ProductUpdateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Update_WithInValidModel_ReturnsBadRequest()
        {
            var mockProductService = new MockProductService().MockUpdateProductAsync(2);
            var controller = new ProductController(mockProductService.Object);
            controller.ModelState.AddModelError("Test", "Test");

            var result = await controller.UpdateProductAsync(new ProductUpdateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Update_WithGetProductByIdAsyncIsNull_ReturnsNotFound()
        {
            var mockProductService = new MockProductService().MockUpdateProductAsync(2).MockGetProductByIdAsync(null);
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.UpdateProductAsync(new ProductUpdateRequest());

            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Delete Product
        [Fact]
        public async void Delete_ReturnsOk()
        {
            var mockProductService = new MockProductService().MockDeleteProductAsync(1);
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.DeleteProductAsync(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Delete_ReturnsBadRequest()
        {
            var mockProductService = new MockProductService().MockDeleteProductAsync_ThrowException();
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.DeleteProductAsync(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Delete_ReturnsNotFound()
        {
            var mockProductService = new MockProductService().MockDeleteProductAsync(0);
            var controller = new ProductController(mockProductService.Object);

            var result = await controller.DeleteProductAsync(1);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        
    }
}
