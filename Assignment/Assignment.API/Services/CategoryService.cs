using Assignment.API.Interfaces;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class CategoryService : ICategoryService
    {
        ApplicationDbContext db;
        public CategoryService(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public async Task<int> AddCategory(Category category)
        {
            if (db != null)
            {
                await db.Categories.AddAsync(category);
                await db.SaveChangesAsync();
                return category.Id;
            }
            return 0;
        }

        public async Task<int> DeleteCategory(int? CategoryId)
        {
            int result = 0;

            if (db != null)
            {
                var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId);

                if (category != null)
                {
                    db.Categories.Remove(category);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            if (db != null)
            {
                return await db.Categories.ToListAsync();
            }
            return null;
        }

        public async Task<Category> GetCategories(int? categoryId)
        {
            if (db != null)
            {
                return await (from c in db.Categories
                              where c.Id == categoryId
                              select c
                             ).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<CategoryViewModel>> GetCategoryDetail(int? categoryId)
        {
            if (db != null)
            {
                return await(from c in db.Categories
                             from p in db.Products
                             from r in db.ProductRatings
                             where c.Id == p.CategoryId && c.Id == categoryId
                             select new CategoryViewModel
                             {
                                 Id = c.Id,
                                 CategoryName = c.CategoryName,
                                 Description = c.Description,
                                 ProductId = p.Id,
                                 ProductName = p.ProductName,
                                 Image = p.Image,
                                 Price = p.Price,
                                 ProductRatingId = p.ProductRatingId,
                                 Start = r.Start,
                                 DescriptionProduct = p.Description,
                                 Qty = p.Qty
                             }).ToListAsync();
            }

            return null;
        }

        public async Task UpdateCategory(Category category)
        {
            if (db != null)
            {
                db.Categories.Update(category);
                await db.SaveChangesAsync();
            }
        }
    }
}
