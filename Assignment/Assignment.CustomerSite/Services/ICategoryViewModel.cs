using Assignment.SharedViewModels.ViewModels;
using Refit;

namespace Assignment.CustomerSite.Services
{
	public interface ICategoryViewModel
	{
		[Get("/api/Categories/GetCategoryDetail/")]
		Task<List<CategoryViewModel>> GetCategoryDetail(int? categoryId);
	}
}
