namespace ICook.Web.ViewModels.Recipe
{
	using AutoMapper;
	using ICook.Data.Models;
	using ICook.Services.Mapping;
	using System.Linq;

	public class RecipeAllViewModel : IMapFrom<Recipe>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ImageUrl { get; set; }

		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<Recipe, RecipeAllViewModel>()
				.ForMember(r => r.ImageUrl, opt =>
				opt.MapFrom(r => 
					r.Images.FirstOrDefault().RemoteImageUrl != null ?
					r.Images.FirstOrDefault().RemoteImageUrl :
					"/images/recipes/" + r.Images.FirstOrDefault().Id + r.Images.FirstOrDefault().Extension));
		}
	}
}
	