using Assignment.API.Interfaces;
using Assignment.Domain.Data;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment.API.Services
{
    public class ProductRatingService : IProductRating

    {
        ApplicationDbContext db;
        private readonly IMapper _mapper;
        public ProductRatingService(ApplicationDbContext _db, IMapper mapper)
        {
            this.db = _db;
            _mapper = mapper;
        }

        public async Task<ProductRatingViewModel> GetProductRatingByIdAsync(int Id)
        {
            var review = await db.ProductRatings.Where(rv => rv.Id == Id).Include(rv => rv.User).SingleOrDefaultAsync();
            if (review == null)
            {
                return null;
            }
            return new ProductRatingViewModel()
            {
                Id = review.Id,
                UserId = review.UserId,
                UserName = review.User.LastName,
                //Name = review.User.FirstName,
                ProductId = review.ProductId,
                Comment = review.Comment,
                Star = review.Start,
                CreatedDate = review.CreatedDate,
                UpdatedDate = review.UpdatedDate
               
            };
        }

        public async Task<int> CreateProductRatingAsync(ProductRatingCreateRequest request)
        {
            if (request == null)
            {
                return 0;
            }
            if (request.Star == 0)
            {
                request.Star = 5;
            }
            var review = new ProductRating()
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Comment = request.Comment,
                Start = request.Star,
                CreatedDate = DateTime.Now
            };
            await db.ProductRatings.AddAsync(review);
            var result = await db.SaveChangesAsync();
            if (result == 0)
            {
                return 0;
            }
            return review.Id;
        }
    }
}
