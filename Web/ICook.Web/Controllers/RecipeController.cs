﻿namespace ICook.Web.Controllers
{
	using ICook.Services.Data;
	using ICook.Web.ViewModels.Recipe;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Security.Claims;
	using System.Threading.Tasks;

	[Authorize]
	public class RecipeController : Controller
	{
		private readonly ICategoryService categoryService;
		private readonly IRecipeService recipeService;

        public RecipeController(ICategoryService categoryService, IRecipeService recipeService)
        {
            this.categoryService = categoryService;
			this.recipeService = recipeService;
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
				string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
				await this.recipeService.AddRecipeAsync(model, userId);
			}
			catch (System.Exception)
			{
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
