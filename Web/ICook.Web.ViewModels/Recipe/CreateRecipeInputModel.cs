namespace ICook.Web.ViewModels.Recipe
{
	using ICook.Web.ViewModels.Ingredient;
	using Microsoft.AspNetCore.Http;
	using System.Collections.Generic;

	public class CreateRecipeInputModel : BaseRecipeInputModel
	{
        public CreateRecipeInputModel() 
        {
			this.Ingredients = new HashSet<IngredientViewModel>();
			this.Images = new HashSet<IFormFile>();
        }

		public IEnumerable<IngredientViewModel> Ingredients { get; set; }

		public IEnumerable<IFormFile> Images { get; set; }
	}
}
