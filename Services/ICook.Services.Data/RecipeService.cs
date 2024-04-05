namespace ICook.Services.Data
{
	using ICook.Data.Common.Repositories;
	using ICook.Data.Models;
	using ICook.Web.ViewModels.Recipe;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using ICook.Services.Mapping;
	using System.IO;
	using static Common.ErrorMessages;

	public class RecipeService : IRecipeService
	{
		private readonly IDeletableEntityRepository<Recipe> recipeRepository;
		private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
		private readonly string[] allowedExtensions = new string[] {".jpg", ".jpeg", ".png"};

        public RecipeService(IDeletableEntityRepository<Recipe> recipeRepository, IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.recipeRepository = recipeRepository;
			this.ingredientRepository = ingredientRepository;
        }

        public async Task AddRecipeAsync(CreateRecipeInputModel model, string userId, string imagePath)
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
					.FirstOrDefaultAsync(i => i.Name == currentIngredient.IngredientName);

				if (ingredient == null)
				{
					ingredient = new Ingredient
					{
						Name = currentIngredient.IngredientName
					};
				}

				RecipeIngredient recipeIngredient = new RecipeIngredient
				{
					Ingredient = ingredient,
					Quantity = currentIngredient.Quantity
				};

				recipe.Ingredients.Add(recipeIngredient);
            }

			foreach (var currentImage in model.Images)
			{
				string imageExtension = Path.GetExtension(currentImage.FileName);

				if (!allowedExtensions.Any(x => x == imageExtension))
				{
					throw new InvalidDataException(InvalidImageFileErrorMessage);
				}

				Image image = new Image
				{
					AddedByUserId = userId,
					Recipe = recipe,
					Extension = imageExtension
				};
				recipe.Images.Add(image);

				Directory.CreateDirectory($"{imagePath}/recipes/");
				string physicalPath = $"{imagePath}/recipes/{image.Id}{imageExtension}";

				using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
				{
					await currentImage.CopyToAsync(fileStream);
				}
			}

			await this.recipeRepository.AddAsync(recipe);
			await this.recipeRepository.SaveChangesAsync();
        }

		public async Task<IEnumerable<T>> GetAllRecipesAsync<T>(int page, int itemsPerPage = 12)
		{
			IEnumerable<T> recipes = await this.recipeRepository
				.AllAsNoTracking()
				.OrderBy(r => r.Category.Name)
				.ThenBy(r => r.Name)
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
				.To<T>()
				.ToArrayAsync();

			return recipes;
		}

		public async Task<int> GetRecipeCountAsync()
		{
			int count = await this.recipeRepository.AllAsNoTracking().CountAsync();
			return count;
		}

		public async Task<T> GetRecipeDetailsByIdAsync<T>(int id)
		{
			var recipeDetail = await this.recipeRepository
				.AllAsNoTracking()
				.Where(r => r.Id == id)
				.To<T>()
				.FirstOrDefaultAsync();

			return recipeDetail;
		}
	}
}
