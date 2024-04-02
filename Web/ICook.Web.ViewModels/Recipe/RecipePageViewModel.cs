namespace ICook.Web.ViewModels.Recipe
{
	using System.Collections.Generic;

	public class RecipePageViewModel
	{
		public int CurrentPage { get; set; }

		public IEnumerable<RecipeAllViewModel> AllRecipes { get; set; }
	}
}
