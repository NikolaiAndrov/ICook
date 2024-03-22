namespace ICook.Web.Controllers
{
    using System.Diagnostics;
	using ICook.Services.Data;
	using ICook.Services.Data.Models;
	using ICook.Web.ViewModels;
    using ICook.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;
       
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            CountsDto counts = this.homeService.GetCounts();

            IndexViewModel model = new IndexViewModel
            {
                RecipesCount = counts.RecipesCount,
                CategoriesCount = counts.CategoriesCount,
                IngredientsCount = counts.IngredientsCount,
                ImagesCount = counts.ImagesCount
            };
            
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
