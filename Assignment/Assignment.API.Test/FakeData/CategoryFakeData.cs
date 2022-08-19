using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Test.FakeData
{
    public class CategoryFakeData
    {
        public static List<Category> ListCategories()
        {
            return new List<Category>() {
                new Category()
                {
                    Id = 1,
                    CategoryName = "Gao1",
                    Description = "Gao1",
                    CreatedDate = DateTime.Now.Date,
                    UpdatedDate = DateTime.Now.Date,
                    IsDeleted = false
                },
                new Category()
                {
                    Id = 1,
                    CategoryName = "Gao2",
                    Description = "Gao2",
                    CreatedDate = DateTime.Now.Date,
                    UpdatedDate = DateTime.Now.Date,
                    IsDeleted = false
                },
                new Category()
                {
                    Id = 1,
                    CategoryName = "Gao3",
                    Description = "Gao3",
                    CreatedDate = DateTime.Now.Date,
                    UpdatedDate = DateTime.Now.Date,
                    IsDeleted = false
                },
                new Category()
                {
                    Id = 1,
                    CategoryName = "Gao4",
                    Description = "Gao4",
                    CreatedDate = DateTime.Now.Date,
                    UpdatedDate = DateTime.Now.Date,
                    IsDeleted = false
                },
            };
        }

        public static CategoryCreateRequest createItemCategory()
        {
            return new CategoryCreateRequest()
            {
                CategoryName = "category create 1",
                Description = "category create description 1",
            };
        }

        public static CategoryUpdateRequest UpdatetemCategory()
        {
            return new CategoryUpdateRequest()
            {
                CategoryName = "category update 1",
                Description = "category update description 1",
            };
        }
    }
}
