using Assignment.API.Interfaces;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class ProductService : IProductService
    {
        ApplicationDbContext db;
        public ProductService(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public async Task<int> AddProduct(Product product)
        {
            if (db != null)
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
                return product.Id;
            }
            return 0;
        }

        public async Task<int> DeleteProduct(int? productId)
        {
            int result = 0;

            if (db != null)
            {
                var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);

                if (product != null)
                {
                    db.Products.Remove(product);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            if (db != null)
            {
                return await db.Products.ToListAsync();
            }
            return null;
        }

        public async Task<Product> GetProduct(int? productId)
        {
            if (db != null)
            {
                return await(from c in db.Products
                             where c.Id == productId
                             select c
                             ).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task UpdateProduct(Product product)
        {
            if (db != null)
            {
                db.Products.Update(product);
                await db.SaveChangesAsync();
            }
        }
    }
}
