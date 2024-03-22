namespace ICook.Web.Controllers
{
	using ICook.Web.ViewModels.Recipe;
	using Microsoft.AspNetCore.Mvc;

	public class RecipeController : Controller
	{
		[HttpGet]
		public IActionResult Create()
		{
			CreateRecipeInputModel model = new CreateRecipeInputModel();

			return this.View(model);
		}

		[HttpPost]
		public IActionResult Create(CreateRecipeInputModel model)
		{
			return this.Ok();
		}
	}
}
