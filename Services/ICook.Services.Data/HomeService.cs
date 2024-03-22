﻿namespace ICook.Services.Data
{
	using ICook.Data.Common.Repositories;
	using ICook.Data.Models;
	using ICook.Web.ViewModels.Home;
	using System.Linq;

	public class HomeService : IHomeService
	{

        private readonly IDeletableEntityRepository<Category> categoryRepository;
		private readonly IRepository<Image> imageRepository;
		private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
		private readonly IDeletableEntityRepository<Recipe> recipeRepository;

		public HomeService(
		   IDeletableEntityRepository<Category> categoryRepository,
		   IRepository<Image> imageRepository,
		   IDeletableEntityRepository<Ingredient> ingredientRepository,
		   IDeletableEntityRepository<Recipe> recipeRepository)
		{
			this.categoryRepository = categoryRepository;
			this.imageRepository = imageRepository;
			this.ingredientRepository = ingredientRepository;
			this.recipeRepository = recipeRepository;
		}

		public IndexViewModel GetIndexViewModelWithCounts()
        {
			IndexViewModel model = new IndexViewModel
			{
				RecipesCount = this.recipeRepository.All().Count(),
				CategoriesCount = this.categoryRepository.All().Count(),
				IngredientsCount = this.ingredientRepository.All().Count(),
				ImagesCount = this.imageRepository.All().Count(),
			};

			return model;
		}
    }
}
