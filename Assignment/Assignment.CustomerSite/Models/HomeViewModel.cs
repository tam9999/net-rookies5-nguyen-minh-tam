using Assignment.SharedViewModels.ViewModels;
using Assignment.Domain.Entities;

namespace Assignment.CustomerSite.Models
{
    public class HomeViewModel
    {
        public List<Category> Categories;       
        public List<Product> Products;
        public ProductViewModel ProductDetail;
        public List<CategoryViewModel> CategoryDetail;
        
    }
}
