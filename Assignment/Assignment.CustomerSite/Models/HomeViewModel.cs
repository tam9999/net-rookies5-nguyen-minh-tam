using Assignment.SharedViewModels.ViewModels;
using Assignment.Domain.Entities;

namespace Assignment.CustomerSite.Models
{
    public class HomeViewModel
    {
        public List<CategoryViewModel> Categories;
        
        public List<ProductViewModel> Products;
        public ProductViewModel ProductDetail;
        public List<CategoryViewModel> CategoryDetail;
        
    }
}
