namespace ICook.Web.ViewModels.Recipe
{
	using ICook.Web.ViewModels.Category;
	using ICook.Web.ViewModels.Ingredient;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using static Common.ValidationConstants.RecipeValidation;

	public class CreateRecipeInputModel
	{
        public CreateRecipeInputModel()
        {
			this.Categories = new HashSet<CategoryViewModel>();
			this.Ingredients = new HashSet<IngredientViewModel>();
        }

		[Required(AllowEmptyStrings = false)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(InstructionsMaxLength, MinimumLength = InstructionsMinLength)]
		public string Instructions { get; set; }

		[Range(PreparationTimeMinValue, PreparationTimeMaxValue)]
		[Display(Name = "Preparation time (in minutes)")]
		public int PreparationTime { get; set; }

		[Range(CookingTimeMinValue, CookingTimeMaxValue)]
		[Display(Name = "Cooking time (in minutes)")]
		public int CookingTime { get; set; }

		[Required]
		[Range(PortionsCountMinValue, PortionsCountMaxValue)]
		[Display(Name = "Portions Count")]
		public int PortionsCount { get; set; }

		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<CategoryViewModel> Categories { get; set; }

		public IEnumerable<IngredientViewModel> Ingredients { get; set; }
	}
}
