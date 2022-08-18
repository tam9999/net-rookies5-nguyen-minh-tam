using Assignment.SharedViewModels.ViewModels;

namespace Assignment.SharedViewModels.Dtos
{
    public class ProductDto
	{
        public List<ProductViewModel> Products { get; set; }
        public int TotalItem { get; set; }
        public int CurrentPage { get; set; }
        public double NumberPage { get; set; }
        public int? PageSize { get; set; }
        public ProductDto()
        {
            this.Products = new List<ProductViewModel>();
        }
    }
}
