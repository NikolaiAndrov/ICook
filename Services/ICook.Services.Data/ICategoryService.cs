namespace ICook.Services.Data
{
	using ICook.Web.ViewModels.Category;
	using System.Collections.Generic;

	public interface ICategoryService
	{
		IEnumerable<CategoryViewModel> GetCategories();
	}
}
