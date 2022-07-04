using Assignment.API.Interfaces;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class ProductService : IProductService
    {
        ApplicationDbContext db;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDbContext _db, IMapper mapper)
        {
            this.db = _db;
            _mapper = mapper;
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

        public async Task<List<ProductViewModel>> GetTop5Async()
        {
            return await db.Products.Select(product => _mapper.Map<ProductViewModel>(product)).Take(5).ToListAsync();
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

        public async Task<ProductViewModel> GetProductDetail(int? productId)
        {
            if (db != null)
            {
                return await(from c in db.Categories
                             from p in db.Products
                             from r in db.ProductRatings
                             where p.Id == productId
                             select new ProductViewModel
                             {
                                 Id = p.Id,
                                 Name = p.ProductName,
                                 CategoryId = p.CategoryId,
                                 CategoryName = c.CategoryName,
                                 Image = p.Image,
                                 Price = p.Price,
                                 ProductRatingId = p.ProductRatingId,
                                 Start = r.Start,
                                 Description = p.Description,
                                 Qty = p.Qty
                             }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<SearchProductViewModel>> SearchByName(string productName)
        {
            if (db != null)
            {
                return await(from c in db.Categories
                             from p in db.Products
                             from r in db.ProductRatings
                             where p.ProductName == productName
                             select new SearchProductViewModel
                             {
                                 
                                 Name = p.ProductName,
                                 Id = p.Id,
                                 CategoryId = p.CategoryId,
                                 CategoryName = c.CategoryName,
                                 Image = p.Image,
                                 Price = p.Price,
                                 ProductRatingId = p.ProductRatingId,
                                 Start = r.Start,
                                 Description = p.Description,
                                 Qty = p.Qty
                             }).ToListAsync();
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

        public Task<List<ProductViewModel>> GetTop8Async()
        {
            throw new NotImplementedException();
        }
    }
}
