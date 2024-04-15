namespace ICook.Services.Data
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Web.ViewModels.Recipe;

	public interface IRecipeService
	{
		Task AddRecipeAsync(CreateRecipeInputModel model, string userId, string imagePath);

		Task<IEnumerable<T>> GetAllRecipesAsync<T>(int page, int itemsPerPage = 12);

		Task<T> GetRecipeByIdAsync<T>(int id);

		Task<List<T>> GetRecipesForIndexAsync<T>();

		Task<int> GetRecipeCountAsync();

		Task<bool> IsUserCreatorOfRecipeAsync(int recipeId, string userId);
	}
}
