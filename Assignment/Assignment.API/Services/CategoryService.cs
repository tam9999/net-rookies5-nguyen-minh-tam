﻿using Assignment.API.Interfaces;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class CategoryService : ICategoryService
    {
        ApplicationDbContext db;
        private readonly IMapper _mapper;
        public CategoryService(ApplicationDbContext _db, IMapper mapper)
        {
            this.db = _db;
            _mapper = mapper;
        }

        public async Task<int> DeleteCategoryAsync(int? categoryId)
        {
            int result = 0;

            if (db != null)
            {
                var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);

                if (category != null)
                {
                    db.Categories.Remove(category);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            if (db != null)
            {
                return await db.Categories.ToListAsync();
            }
            return null;

        }

        public async Task<Category> GetCategoryAsync(int? categoryId)
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

        public async Task<List<CategoryViewModel>> GetCategoryDetailAsync(int? categoryId)
        {
            //return await db.Categories.Where(x => x.Id == categoryId).Select(category => _mapper.Map<CategoryViewModel>(category)).ToListAsync();
            if (db != null)
            {
                return await (from c in db.Categories
                              from p in db.Products
                              //from r in db.ProductRatings
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
                                  //Start = r.Start,
                                  DescriptionProduct = p.Description,
                                  Qty = p.Qty
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<int> UpdateCategoryAsync(CategoryUpdateRequest request)
        {
            var category = await db.Categories.FindAsync(request.Id);
            if (category == null)
            {
                throw new Exception($"Cannot find category with Id = {request.Id}");
            }
            category.CategoryName = request.CategoryName;
            category.Description = request.Description;
            category.UpdatedDate = DateTime.Now;
            return await db.SaveChangesAsync();

        }

        public async Task<int> AddCategoryAsync(CategoryCreateRequest request)
        {
            if (string.IsNullOrEmpty(request.CategoryName))
            {
                return 0;
            }
            var category = new Category()
            {
                CategoryName = request.CategoryName,
                Description = request.Description,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            return category.Id;
        }
    }
}
