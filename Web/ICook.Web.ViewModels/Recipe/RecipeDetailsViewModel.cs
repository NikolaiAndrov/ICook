namespace ICook.Web.ViewModels.Recipe
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper;
	using ICook.Services.Mapping;
	using ICook.Web.ViewModels.Ingredient;
	using ICook.Data.Models;

	internal class RecipeDetailsViewModel : IMapFrom<Recipe>, IHaveCustomMappings
	{
        public RecipeDetailsViewModel()
        {
            this.Ingredients = new List<IngredientViewModel>();
        }

        public int Id { get; set; }

		public string Name { get; set; }

		public string ImageUrl { get; set; }

		public TimeSpan PreparationTime { get; set; }

		public TimeSpan CookingTime { get; set; }

		public DateTime CreatedOn { get; set; }

		public string Instructions { get; set; }

		public int PortionsCount { get; set; }

		public string CategoryName { get; set; }

		public IEnumerable<IngredientViewModel> Ingredients { get; set; }

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<Recipe, RecipeDetailsViewModel>()
				.ForMember(r => r.ImageUrl, opt =>
				opt.MapFrom(r =>
					r.Images.FirstOrDefault().RemoteImageUrl != null ?
					r.Images.FirstOrDefault().RemoteImageUrl :
					"/images/recipes/" + r.Images.FirstOrDefault().Id + r.Images.FirstOrDefault().Extension));
		}
	}
}
