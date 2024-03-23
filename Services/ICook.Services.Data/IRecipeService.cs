namespace ICook.Services.Data
{
	using ICook.Web.ViewModels.Recipe;
	using System.Threading.Tasks;

	public interface IRecipeService
	{
		Task AddRecipeAsync(CreateRecipeInputModel model, string userId);
	}
}
