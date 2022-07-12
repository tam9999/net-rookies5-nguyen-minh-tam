using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomerSite.Services
{
    public interface IProductRating
    {
        [Post("/api/ProductRating")]
        Task<ProductRatingViewModel> CreateProductRatingAsync(RatingCreateRequest request);

        [Get("/api/ProductRating/{id}")]
        Task<List<ProductRatingViewModel>> GetProductRatingByIdAsync(int id);
    }
}
