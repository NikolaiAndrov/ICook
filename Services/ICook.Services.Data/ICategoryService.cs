namespace ICook.Services.Data
{
	using System.Collections.Generic;

	using Web.ViewModels.Category;

	public interface ICategoryService
	{
		IEnumerable<CategoryViewModel> GetCategories();
	}
}
