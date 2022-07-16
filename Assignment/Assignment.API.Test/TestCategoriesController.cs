using Assignment.API.Controllers;
using Assignment.API.Test.Mocks;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assignment.API.Test
{
    public class TestCategoriesController
    {
        //Get All Category
        [Fact]
        public async void GetAllCategory_ReturnsOk()
        {
            var mockData = new List<Category>()
            {
                 new Category()
                 {
                      Id = 1,
                 },
            };

            var mockCategoryService = new MockCategoryService().MockGetAllCategoryAsync(mockData);

            var controller = new CategoriesController(mockCategoryService.Object);

            OkObjectResult result = await controller.GetAllCategoryAsync() as OkObjectResult;

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            
        }

        [Fact]
        public async void GetAllCategory_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockGetAllCategoryAsync_ThrowException();

            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.GetAllCategoryAsync();

            Assert.IsType<BadRequestObjectResult>(result);
        }

        //Get One Category
        [Fact]
        public async void GetCategoryAsync_ReturnsOk()
        {
            var mockData = new Category()
            {
                Id = 1,
            };

            var mockCategoryService = new MockCategoryService().MockGetCategoryAsync(mockData);

            var controller = new CategoriesController(mockCategoryService.Object);

            OkObjectResult result = await controller.GetCategoryAsync(1) as OkObjectResult;

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetCategoryAsync_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockGetCategoryAsync_ThrowException();

            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.GetCategoryAsync(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        //Add Category
        [Fact]
        public async void Create_WithValidModel_ReturnsOk()
        {
            var mockCategoryService = new MockCategoryService().MockAddCategoryAsync(1).MockGetCategoryAsync(new Category());
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.AddCategoryAsync(new CategoryCreateRequest()) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);

            var content = JsonConvert.DeserializeObject<CategoryViewModel>(result.Value.ToString());
            Assert.IsType<CategoryViewModel>(content);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Create_WithValidModelAndProductIdIsZero_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockAddCategoryAsync(0);
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.AddCategoryAsync(new CategoryCreateRequest());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void Create_WithValidModelAndException_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockAddCategoryAsync_ThrowException();
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.AddCategoryAsync(new CategoryCreateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Create_WithInValidModel_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockAddCategoryAsync(2);
            var controller = new CategoriesController(mockCategoryService.Object);
            controller.ModelState.AddModelError("Test", "Test");

            var result = await controller.AddCategoryAsync(new CategoryCreateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Create_WithGetCategoryAsyncIsNull_ReturnsNotFound()
        {
            var mockCategoryService = new MockCategoryService().MockAddCategoryAsync(2).MockGetCategoryAsync(null);
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.AddCategoryAsync(new CategoryCreateRequest());

            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Update Category
        [Fact]
        public async void Update_WithValidModel_ReturnsOk()
        {
            var mockCategoryService = new MockCategoryService().MockUpdateAsync(1).MockGetCategoryAsync(new Category());
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.Update(new CategoryUpdateRequest()) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);

            var content = JsonConvert.DeserializeObject<CategoryViewModel>(result.Value.ToString());
            Assert.IsType<CategoryViewModel>(content);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Update_WithValidModelAndException_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockUpdateAsync_ThrowException();
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.Update(new CategoryUpdateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Update_WithInValidModel_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockUpdateAsync(2);
            var controller = new CategoriesController(mockCategoryService.Object);
            controller.ModelState.AddModelError("Test", "Test");

            var result = await controller.Update(new CategoryUpdateRequest());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Update_WithGetCategoryAsyncIsNull_ReturnsNotFound()
        {
            var mockCategoryService = new MockCategoryService().MockUpdateAsync(2).MockGetCategoryAsync(null);
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.Update(new CategoryUpdateRequest());

            Assert.IsType<NotFoundObjectResult>(result);
        }

        //Delete Category
        [Fact]
        public async void Delete_ReturnsOk()
        {
            var mockCategoryService = new MockCategoryService().MockDeleteCategoryAsync(1);
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.DeleteCategoryAsync(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Delete_ReturnsBadRequest()
        {
            var mockCategoryService = new MockCategoryService().MockDeleteCategoryAsync_ThrowException();
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.DeleteCategoryAsync(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async void Delete_ReturnsNotFound()
        {
            var mockCategoryService = new MockCategoryService().MockDeleteCategoryAsync(0);
            var controller = new CategoriesController(mockCategoryService.Object);

            var result = await controller.DeleteCategoryAsync(1);

            Assert.IsType<NotFoundObjectResult>(result);
        }

    }
}