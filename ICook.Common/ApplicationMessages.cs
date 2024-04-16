namespace ICook.Common
{
	public static class ApplicationMessages
	{
		public const string SuccessMessage = "SuccessMessage";
		public const string ErrorMessage = "ErrorMessage";

		public const string RecipeAddedSuccessfullyMessage = "New recipe added successfully!";
		public const string RecipeDeletedSuccessfully = "The recipe was deleted successfully!";
		public const string RecipeNotFoundMessage = "Recipe not found!";
		public const string UnexpectedErrorMessage = "Unexpected error occured while proccessing your request!";
		public const string UnauthorizedMessage = "You are not authorized to perform this action!";

		public const string EmptyImagesErrorMessage = "You should upload at least 1 image!";
		public const string TooManyImagesErrorMessage = "You cannot upload more than 5 images!";

		public const string InvalidImageFileErrorMessage = "Allowed image files are: jpeg and png!";
	}
}
