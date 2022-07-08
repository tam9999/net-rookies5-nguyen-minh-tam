﻿using Assignment.SharedViewModels.Requests;
using Assignment.SharedViewModels.ViewModels;

namespace Assignment.API.Interfaces
{
    public interface IProductRating
    {
        Task<ProductRatingViewModel> GetProductRatingByIdAsync(int Id);
        Task<int> CreateProductRatingAsync(ProductRatingCreateRequest request);
    }
}
