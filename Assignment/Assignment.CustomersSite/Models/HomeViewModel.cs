using Assignment.SharedViewModels.ViewModels;
using Assignment.Domain.Entities;

namespace Asignment.CustomersSite.Models
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public ProductViewModel ProductDeatil { get; set; }
    }
}
