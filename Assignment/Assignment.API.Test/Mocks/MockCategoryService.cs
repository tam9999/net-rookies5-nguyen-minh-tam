using Assignment.API.Interfaces;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using Moq;

namespace Assignment.API.Test.Mocks
{
    public class MockCategoryService : Mock<ICategoryService>
    {
        //Get All Category
        public MockCategoryService MockGetAllCategoryAsync(List<Category> result)
        {
            Setup(x => x.GetAllCategoryAsync()).ReturnsAsync(result);

            return this;
        }

        public MockCategoryService MockGetAllCategoryAsync_ThrowException()
        {
            Setup(x => x.GetAllCategoryAsync()).Throws(new Exception());

            return this;
        }
        //Get One Category
        public MockCategoryService MockGetCategoryAsync(Category result)
        {
            Setup(x => x.GetCategoryAsync(It.IsAny<int>())).ReturnsAsync(result);

            return this;
        }

        public MockCategoryService MockGetCategoryAsync_ThrowException()
        {
            Setup(x => x.GetCategoryAsync(It.IsAny<int>())).Throws(new Exception());

            return this;
        }
        //Add Category
        public MockCategoryService MockAddCategoryAsync(int result)
        {
            Setup(x => x.AddCategoryAsync(It.IsAny<CategoryCreateRequest>())).ReturnsAsync(result);
            return this;
        }

        public MockCategoryService MockAddCategoryAsync_ThrowException()
        {
            Setup(x => x.AddCategoryAsync(It.IsAny<CategoryCreateRequest>())).Throws(new Exception());
            return this;
        }
        //Update Category
        public MockCategoryService MockUpdateAsync(int result)
        {
            Setup(x => x.UpdateCategoryAsync(It.IsAny<CategoryUpdateRequest>())).ReturnsAsync(result);
            return this;
        }

        public MockCategoryService MockUpdateAsync_ThrowException()
        {
            Setup(x => x.UpdateCategoryAsync(It.IsAny<CategoryUpdateRequest>())).Throws(new Exception());
            return this;
        }

        //Delete Category
        public MockCategoryService MockDeleteCategoryAsync(int result)
        {
            Setup(x => x.DeleteCategoryAsync(It.IsAny<int>())).ReturnsAsync(result);
            return this;
        }

        public MockCategoryService MockDeleteCategoryAsync_ThrowException()
        {
            Setup(x => x.DeleteCategoryAsync(It.IsAny<int>())).Throws(new Exception());
            return this;
        }
    }
}
