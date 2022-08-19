using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Dtos;
using Assignment.SharedViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment.API.Test.FakeData
{
    public class ProductFakeData
    {
        public static List<Product> ListProductst()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    ProductName = "Gao test 1",
                    Qty = 10,
                    Image = "gao1.png",
                    Price = 200000,
                    CreatedDate = DateTime.Now,
                    Description = "test1 Description",
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    CategoryId = 1,
                    ProductRatingId = 0,
                    ImageId = 0
                },

                new Product()
                {
                    Id = 2,
                    ProductName = "Gao test 1",
                    Qty = 10,
                    Image = "gao2.png",
                    Price = 200000,
                    CreatedDate = DateTime.Now,
                    Description = "test2 Description",
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    CategoryId = 2,
                    ProductRatingId = 0,
                    ImageId = 0
                },
             };
        }

        public static ProductDto PagingItemProduct()
        {
            return new ProductDto()
            {
                TotalItem = 10,
                CurrentPage = 1,
                NumberPage = 3,
                PageSize = 3
            };
        }

        public static ProductCreateRequest createItemProduct()
        {
            return new ProductCreateRequest()
            {
                Description = "test Description",
                Price = 100000,
                ProductName = "Gao test2"
            };
        }

        public static ProductUpdateRequest UpdatetemProduct()
        {
            return new ProductUpdateRequest()
            {
                Description = "update Description",
                Price = 100000,
                ProductName = "Gao update",
            };
        }
    }
}
