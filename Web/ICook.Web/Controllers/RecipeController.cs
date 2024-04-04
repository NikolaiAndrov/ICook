namespace ICook.Web.Controllers
{
	using ICook.Services.Data;
	using ICook.Web.ViewModels.Recipe;
    using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Linq;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using static Common.ErrorMessages;

	[Authorize]
	public class RecipeController : Controller
	{
		private readonly ICategoryService categoryService;
		private readonly IRecipeService recipeService;
		private readonly IWebHostEnvironment hostEnvironment;

        public RecipeController(ICategoryService categoryService, IRecipeService recipeService, IWebHostEnvironment hostEnvironment)
        {
            this.categoryService = categoryService;
			this.recipeService = recipeService;
			this.hostEnvironment = hostEnvironment;	
        }

        [HttpGet]
		public IActionResult Create()
		{
			CreateRecipeInputModel model = new CreateRecipeInputModel();

			try
			{
				model.Categories = this.categoryService.GetCategories();
			}
			catch (System.Exception)
			{
				return this.RedirectToAction("Index", "Home");
			}

			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateRecipeInputModel model)
		{
			if (!model.Images.Any())
			{
				this.ModelState.AddModelError(nameof(model.Images), EmptyImagesErrorMessage);
			}

			if (model.Images.Count() > 5)
			{
				this.ModelState.AddModelError(nameof(model.Images), TooManyImagesErrorMessage);
			}

			if (!this.ModelState.IsValid)
			{
				try
				{
					model.Categories = this.categoryService.GetCategories();
				}
				catch (System.Exception)
				{
					return this.RedirectToAction("Index", "Home");
				}

				return this.View(model);
			}

			try
			{
				string imagePath = $"{this.hostEnvironment.WebRootPath}/images";
				string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
				await this.recipeService.AddRecipeAsync(model, userId, imagePath);
			}
			catch (System.Exception ex)
			{
				if (ex.Message == InvalidImageFileErrorMessage)
				{
					this.ModelState.AddModelError(nameof(model.Images), ex.Message);
					model.Categories = this.categoryService.GetCategories();
					return this.View(model);
				}
				return this.RedirectToAction("Index", "Home");
			}

			return this.RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> All(int id = 1)
		{
			if (id <= 0)
			{
				return this.NotFound();
			}

			const int itemsPerPage = 12;

			RecipePageViewModel pageViewModel = new RecipePageViewModel
			{
				CurrentPage = id,
				ItemsPerPage = itemsPerPage,
			};

			try
			{
				pageViewModel.AllRecipes = await this.recipeService.GetAllRecipesAsync<RecipeAllViewModel>(id, itemsPerPage);
				pageViewModel.RecipesCount = await this.recipeService.GetRecipeCountAsync();
			}
			catch (Exception)
			{
				return this.RedirectToAction("Index", "Home");
			}

			if (id > pageViewModel.PagesCount)
			{
				return this.NotFound();
			}

			return this.View(pageViewModel);
		}
	}
}
