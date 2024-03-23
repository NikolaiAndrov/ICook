namespace ICook.Services.Data
{
	using ICook.Data.Common.Repositories;
	using ICook.Data.Models;
	using ICook.Web.ViewModels.Recipe;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class RecipeService : IRecipeService
	{
		private readonly IDeletableEntityRepository<Recipe> recipeRepository;
		private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public RecipeService(IDeletableEntityRepository<Recipe> recipeRepository, IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.recipeRepository = recipeRepository;
			this.ingredientRepository = ingredientRepository;
        }

        public async Task AddRecipeAsync(CreateRecipeInputModel model, string userId)
		{
			Recipe recipe = new Recipe
			{
				Name = model.Name,
				Instructions = model.Instructions,
				PreparationTime = TimeSpan.FromMinutes(model.PreparationTime),
				CookingTime = TimeSpan.FromMinutes(model.CookingTime),
				PortionsCount = model.PortionsCount,
				UserId = userId,
				CategoryId = model.CategoryId
			};

            foreach (var currentIngredient in model.Ingredients)
            {
				Ingredient ingredient = await this.ingredientRepository.All()
					.FirstOrDefaultAsync(i => i.Name == currentIngredient.Name);

				if (ingredient == null)
				{
					ingredient = new Ingredient
					{
						Name = currentIngredient.Name
					};
				}

				RecipeIngredient recipeIngredient = new RecipeIngredient
				{
					Ingredient = ingredient,
					Quantity = currentIngredient.Quantity
				};

				recipe.Ingredients.Add(recipeIngredient);
            }

			await this.recipeRepository.AddAsync(recipe);
			await this.recipeRepository.SaveChangesAsync();
        }
	}
}
