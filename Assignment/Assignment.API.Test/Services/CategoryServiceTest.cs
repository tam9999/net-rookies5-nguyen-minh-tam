using Assignment.API.Interfaces;
using Assignment.API.Services;
using Assignment.API.Test.Data;
using Assignment.Domain.Data;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.API.Test.Services
{
    
    public class CategoryServiceTest : SQLiteContext
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryServiceTest()
        {
            _dbContext = CreateContext();
        }
        private ICategoryService GetSqlLiteService()
        {
            var mockFileStorage = new Mock<IMapper>();
            return new CategoryService(_dbContext, mockFileStorage.Object);
        }
        //[Fact]
        //public async void GetListCategory_WhenCall_ReturnListCategory()
        //{
        //    ICategoryService service = GetSqlLiteService();
        //    var result = await service.GetAllCategoryAsync();
        //    //Assert.Equal(2, result.Count);
        //    Assert.NotNull(result);
        //}
    }
}
