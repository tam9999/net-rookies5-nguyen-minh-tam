using Assignment.API.Test.FakeData;
using Assignment.Domain.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Assignment.API.Test.Data
{
    public abstract class SQLiteContext
    {
        public DbConnection _connection;
        public DbContextOptions<ApplicationDbContext> _contextOptions;
        public SQLiteContext()
        {
            _connection = new SqliteConnection("Filename =:memory:");
            _connection.Open();
            _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseSqlite(_connection)
               .Options;
            var dbContext = new ApplicationDbContext(_contextOptions);
            if (dbContext.Database.EnsureCreated())
            {
                dbContext.Products.AddRange(ProductFakeData.ListProductst());
                dbContext.Categories.AddRange(CategoryFakeData.ListCategories());
                dbContext.SaveChangesAsync();
            }
        }
        public ApplicationDbContext CreateContext() => new ApplicationDbContext(_contextOptions);
    }
    
}
