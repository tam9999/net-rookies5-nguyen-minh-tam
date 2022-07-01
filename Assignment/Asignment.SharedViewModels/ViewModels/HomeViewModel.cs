using Assignment.Domain.Entities;

namespace Asignment.SharedViewModels.ViewModels
{
    public class HomeViewModel 
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
