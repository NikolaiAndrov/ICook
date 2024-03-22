namespace ICook.Common
{
	public static class ValidationConstants
	{
		public static class RecipeValidation
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 100;

			public const int InstructionsMinLength = 10;
			public const int InstructionsMaxLength = 3000;

			public const int PortionsCountMinValue = 1;
			public const int PortionsCountMaxValue = 100;

			public const int PreparationTimeMinValue = 1;
			public const int PreparationTimeMaxValue = 24 * 60;

			public const int CookingTimeMinValue = 1;
			public const int CookingTimeMaxValue = 24 * 60;
		}

		public static class IngredientValidation
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 100;

			public const int QuantityMinLength = 1;
			public const int QuantityMaxLength = 100;
		}
	}
}
