namespace ICook.Web.ViewModels.Recipe
{
	using ICook.Web.ViewModels.Pagination;
	using System.Collections.Generic;

	public class RecipePageViewModel : BasePaginationModel
	{
		public IEnumerable<RecipeAllViewModel> AllRecipes { get; set; }
	}
}
