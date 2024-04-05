namespace ICook.Services.Data
{
	using ICook.Web.ViewModels.Recipe;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IRecipeService
	{
		Task AddRecipeAsync(CreateRecipeInputModel model, string userId, string imagePath);

		Task<IEnumerable<T>> GetAllRecipesAsync<T>(int page, int itemsPerPage = 12);

		Task<T> GetRecipeDetailsByIdAsync<T>(int id);

		Task<int> GetRecipeCountAsync();
	}
}
