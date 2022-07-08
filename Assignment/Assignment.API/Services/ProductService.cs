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
        public async Task<int> AddProductAsync(Product product)
        {
            if (db != null)
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
                return product.Id;
            }
            return 0;
        }

        public async Task<int> DeleteProductAsync(int? productId)
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

        public async Task<List<Product>> GetAllProductAsync()
        {
            if (db != null)
            {
                return await db.Products.ToListAsync();
            }
            return null;
        }

        public async Task<Product> GetProductByIdAsync(int? Id)
        {
            if (db != null)
            {
                return await(from p in db.Products
                             where p.Id == Id
                             select p
                             ).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<ProductViewModel> GetProductDetailAsync(int? productId)
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

        public async Task<List<SearchProductViewModel>> SearchByNameAsync(string productName)
        {
            //return await db.Products.Where(x => x.ProductName.Contains(productName)).Select(product => _mapper.Map<SearchProductViewModel>(product)).ToListAsync();
            return await db.Products.Where(p => p.ProductName.Contains(productName) && p.IsDeleted == true).Select(product => new SearchProductViewModel()
            {
                Id = product.Id,
                Name = product.ProductName,
                CategoryId = product.CategoryId,
                Image = product.Image,
                Price = product.Price,
                ProductRatingId = product.ProductRatingId,
                Description = product.Description,
                Qty = product.Qty,
            }).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (db != null)
            {
                db.Products.Update(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<ProductViewModel>> GetTop8Async()
        {           
            return await db.Products.Select(product => _mapper.Map<ProductViewModel>(product)).Take(8).ToListAsync();
        }
    }
}
