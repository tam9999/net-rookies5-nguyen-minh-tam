using Assignment.SharedViewModels.ViewModels;
using Assignment.Domain.Entities;
using Assignment.SharedViewModels.Auth;

namespace Assignment.CustomerSite.Models
{
    public class HomeViewModel
    {   
        //get list
        public List<Category> Categories;       
        public List<ProductViewModel> Products;
        //get by id
        public ProductViewModel ProductDetail;
        public List<CategoryViewModel> CategoryDetail;
        public List<SearchProductViewModel> SearchProducts;
        public ProductRatingViewModel ProductRating;
        public List<ProductRatingViewModel> Comments;
        //auth
        //public RegisterRequestViewModel register;
    }
}
