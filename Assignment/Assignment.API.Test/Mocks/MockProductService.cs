using Assignment.API.Interfaces;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Test.Mocks
{
    public class MockProductService : Mock<IProductService>
    {
        //Get All Product
        //public MockProductService MockGetAllProductAsync(List<ProductViewModel> result)
        //{
        //    Setup(x => x.GetAllProductAsync()).ReturnsAsync(result);
        //    return this;
        //}

        //public MockProductService MockGetAllProductAsync_ThrowException()
        //{
        //    Setup(x => x.GetAllProductAsync()).Throws(new Exception());
        //    return this;
        //}
        //Get Product By Id
        public MockProductService MockGetProductByIdAsync(ProductViewModel result)
        {
            Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(result);
            return this;
        }

        public MockProductService MockGetProductByIdAsync_ThrowException()
        {
            Setup(x => x.GetProductByIdAsync(It.IsAny<int>())).Throws(new Exception());
            return this;
        }

        //Add Product
        public MockProductService MockAddProductAsync(int result)
        {
            Setup(x => x.AddProductAsync(It.IsAny<ProductCreateRequest>())).ReturnsAsync(result);
            return this;
        }

        public MockProductService MockAddProductAsync_ThrowException()
        {
            Setup(x => x.AddProductAsync(It.IsAny<ProductCreateRequest>())).Throws(new Exception());
            return this;
        }

        //Update Product
        public MockProductService MockUpdateProductAsync(int result)
        {
            Setup(x => x.UpdateProductAsync(It.IsAny<ProductUpdateRequest>())).ReturnsAsync(result);
            return this;
        }

        public MockProductService MockUpdateProductAsync_ThrowException()
        {
            Setup(x => x.UpdateProductAsync(It.IsAny<ProductUpdateRequest>())).Throws(new Exception());
            return this;
        }

        //Delete Product
        public MockProductService MockDeleteProductAsync(int result)
        {
            Setup(x => x.DeleteProductAsync(It.IsAny<int>())).ReturnsAsync(result);
            return this;
        }

        public MockProductService MockDeleteProductAsync_ThrowException()
        {
            Setup(x => x.DeleteProductAsync(It.IsAny<int>())).Throws(new Exception());
            return this;
        }

    }
}
