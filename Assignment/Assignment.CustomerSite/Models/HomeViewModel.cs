using Assignment.SharedViewModels.ViewModels;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Auth;
using Assignment.API.Requests;
using Assignment.API.Responses;
using Assignment.SharedViewModels.Dtos;

namespace Assignment.CustomerSite.Models
{
    public class HomeViewModel
    {   
        //get list
        public List<Category> Categories;
        //public List<ProductViewModel> Products;
        public ProductDto Products;
        //get by id
        public ProductViewModel ProductDetail;
        public List<CategoryViewModel> CategoryDetail;
        public List<SearchProductViewModel> SearchProducts;
        public ProductRatingViewModel ProductRating;
        public List<ProductRatingViewModel> Comments;
        //auth
        public SignupRequest RegisterRequest;
        public string Register;
        public LoginRequest LoginRequest;
        public TokenResponse user;
        public LogoutResponse Logout;
    }
}
