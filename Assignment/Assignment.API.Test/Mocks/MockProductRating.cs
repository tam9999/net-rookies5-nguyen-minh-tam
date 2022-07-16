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
    public class MockProductRating : Mock<IProductRating>
    {
        public MockProductRating MockGetProductRatingByProductIdAsync(ProductRatingViewModel result)
        {
            Setup(x => x.GetProductRatingByProductIdAsync(It.IsAny<int>()));
            return this;
        }

        public MockProductRating MockGetProductRatingByProductIdAsync_ThrowException()
        {
            Setup(x => x.GetProductRatingByProductIdAsync(It.IsAny<int>())).Throws(new Exception());
            return this;
        }
         

        public MockProductRating MockCreateProductRatingAsync(int result)
        {
            Setup(x => x.CreateProductRatingAsync(It.IsAny<ProductRatingCreateRequest>())).ReturnsAsync(result);
            return this;
        }

        public MockProductRating MockCreateProductRatingAsync_ThrowException()
        {
            Setup(x => x.CreateProductRatingAsync(It.IsAny<ProductRatingCreateRequest>())).Throws(new Exception());
            return this;
        }

    }
}
