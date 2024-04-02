namespace ICook.Web.ViewModels.Recipe
{
	using System;
	using System.Collections.Generic;

	public class RecipePageViewModel
	{
		public int CurrentPage { get; set; }

		public IEnumerable<RecipeAllViewModel> AllRecipes { get; set; }

		public int RecipesCount { get; set; }

		public int ItemsPerPage { get; set; }

		public bool HasPreviousPage => this.CurrentPage > 1;

		public bool HasNextPage => this.CurrentPage < this.PagesCount;

		public int PreviousPage => this.CurrentPage - 1;

		public int NextPage => this.CurrentPage + 1;

		public int PagesCount => (int)Math.Ceiling((double)this.RecipesCount / this.ItemsPerPage);
	}
}
