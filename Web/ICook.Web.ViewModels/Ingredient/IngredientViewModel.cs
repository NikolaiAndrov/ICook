namespace ICook.Web.ViewModels.Ingredient
{
	using System.ComponentModel.DataAnnotations;
	using static Common.ValidationConstants.IngredientValidation;

	public class IngredientViewModel
	{
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(QuantityMaxLength, MinimumLength = QuantityMinLength)]
		public string Quantity { get; set; }
	}
}
