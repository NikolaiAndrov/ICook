namespace ICook.Web.ViewModels.Home
{
    using System.Linq;
    using AutoMapper;
    using ICook.Data.Models;
    using ICook.Services.Mapping;
    using ICook.Web.ViewModels.Recipe;

    public class IndexRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, IndexRecipeViewModel>()
                .ForMember(r => r.ImageUrl, opt =>
                opt.MapFrom(r =>
                    r.Images.FirstOrDefault().RemoteImageUrl != null ?
                    r.Images.FirstOrDefault().RemoteImageUrl :
                    "/images/recipes/" + r.Images.FirstOrDefault().Id + r.Images.FirstOrDefault().Extension));
        }
    }
}
