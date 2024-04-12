namespace ICook.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

	using ICook.Services.Data;
	using ICook.Services.Data.Models;
	using ViewModels;
    using ViewModels.Home;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;
        private readonly IRecipeService recipeService;
       
        public HomeController(IHomeService homeService, IRecipeService recipeService)
        {
            this.homeService = homeService;
            this.recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel model;

            try
            {
                CountsDto counts = this.homeService.GetCounts();

                model = new IndexViewModel
                {
                    RecipesCount = counts.RecipesCount,
                    CategoriesCount = counts.CategoriesCount,
                    IngredientsCount = counts.IngredientsCount,
                    ImagesCount = counts.ImagesCount,
                    Recipes = await this.recipeService.GetRecipesForIndexAsync<IndexRecipeViewModel>()
                };
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
            
            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
