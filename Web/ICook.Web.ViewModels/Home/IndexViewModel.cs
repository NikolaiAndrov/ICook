namespace ICook.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.Recipes = new List<IndexRecipeViewModel>();
        }

        public int RecipesCount { get; set; }

        public int CategoriesCount { get; set; }

        public int IngredientsCount { get; set; }

        public int ImagesCount { get; set; }

        public virtual List<IndexRecipeViewModel> Recipes { get; set; }
    }
}
