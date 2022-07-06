using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomerSite.Services
{
	public interface ICategoryViewModel
	{
		[Get("/api/Category/GetCategoryDetail/{categoryId}")]
		Task<List<CategoryViewModel>> GetCategoryDetail(int? categoryId);
	}
}
