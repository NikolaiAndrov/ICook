namespace ICook.Web.ViewModels.Ingredient
{
	using System.ComponentModel.DataAnnotations;
	using ICook.Services.Mapping;
	using ICook.Data.Models;
	using static Common.ValidationConstants.IngredientValidation;

	public class IngredientViewModel : IMapFrom<RecipeIngredient>
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string IngredientName { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
		public string Quantity { get; set; }
	}
}
