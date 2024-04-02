namespace ICook.Data.Seeding
{
    using ICook.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class RecipeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Recipes.AnyAsync())
            {
                return;
            }

            ICollection<Recipe> recipes = new List<Recipe>();

            Category category = await dbContext.Categories
                .Where(c => c.Name == "Desserts")
                .FirstOrDefaultAsync();

            Image image = new Image
            {
                RemoteImageUrl = "https://d2vsf1hynzxim7.cloudfront.net/production/media/24450/responsive-images/banana-ice-cream-sundaes___default_2480_1860.webp"
            };

            Ingredient ingredient1 = new Ingredient { Name = "Banana" };
            Ingredient ingredient2 = new Ingredient { Name = "Ice Cream" };
            Ingredient ingredient3 = new Ingredient { Name = "Vanilla" };
            Ingredient ingredient4 = new Ingredient { Name = "Wafer Cookie" };
            Ingredient ingredient5 = new Ingredient { Name = "Topping" };

            Recipe recipe = new Recipe
            {
                Name = "Banana Pudding Ice Cream Sundaes",
                Instructions = "Place frozen banana chunks in a high-powered blender or food processor and begin to process on low. (It will look grainy.) Turn off machine and use a rubber spatula to scrape down the sides. Continue processing until bananas get creamy and increase in volume, scraping down the sides as necessary. \r\nRemove to a bowl. Slowly fold in 1 cup whipped topping and 1/2 cup vanilla wafers. Transfer to 4 dishes and top each with additional whipped topping, vanilla wafers and sliced banana.",
                PreparationTime = TimeSpan.FromMinutes(15),
                CookingTime = TimeSpan.FromMinutes(15),
                OriginalUrl = "https://foodnetwork.co.uk/recipes/banana-pudding-ice-cream-sundaes",
                PortionsCount = 1,
                Category = category
            };
            recipe.Images.Add(image);

            RecipeIngredient recipeIngredient1 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient1 };
            RecipeIngredient recipeIngredient2 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient2 };
            RecipeIngredient recipeIngredient3 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient3 };
            RecipeIngredient recipeIngredient4 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient4 };
            RecipeIngredient recipeIngredient5 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient5 };

            recipe.Ingredients.Add(recipeIngredient1);
            recipe.Ingredients.Add(recipeIngredient2);
            recipe.Ingredients.Add(recipeIngredient3);
            recipe.Ingredients.Add(recipeIngredient4);
            recipe.Ingredients.Add(recipeIngredient5);

            recipes.Add(recipe);

            await dbContext.AddRangeAsync(recipes);
            await dbContext.SaveChangesAsync();
        }

        private async Task<ICollection<Recipe>> CreateRecipesAsync(ApplicationDbContext dbContext)
        {
            ICollection<Recipe> recipes = new List<Recipe>();

            Category category = await dbContext.Categories
                .Where(c => c.Name == "Desserts")
                .FirstOrDefaultAsync();

            Image image = new Image
            {
                RemoteImageUrl = "https://d2vsf1hynzxim7.cloudfront.net/production/media/24450/responsive-images/banana-ice-cream-sundaes___default_2480_1860.webp"
            };

            Ingredient ingredient1 = new Ingredient { Name = "Banana" };
            Ingredient ingredient2 = new Ingredient { Name = "Ice Cream" };
            Ingredient ingredient3 = new Ingredient { Name = "Vanilla" };
            Ingredient ingredient4 = new Ingredient { Name = "Wafer Cookie" };
            Ingredient ingredient5 = new Ingredient { Name = "Topping" };

            Recipe recipe = new Recipe
            {
                Name = "Banana Pudding Ice Cream Sundaes",
                Instructions = "Place frozen banana chunks in a high-powered blender or food processor and begin to process on low. (It will look grainy.) Turn off machine and use a rubber spatula to scrape down the sides. Continue processing until bananas get creamy and increase in volume, scraping down the sides as necessary. \r\nRemove to a bowl. Slowly fold in 1 cup whipped topping and 1/2 cup vanilla wafers. Transfer to 4 dishes and top each with additional whipped topping, vanilla wafers and sliced banana.",
                PreparationTime = TimeSpan.FromMinutes(15),
                CookingTime = TimeSpan.FromMinutes(15),
                OriginalUrl = "https://foodnetwork.co.uk/recipes/banana-pudding-ice-cream-sundaes",
                PortionsCount = 1,
                Category = category
            };
            recipe.Images.Add(image);

            RecipeIngredient recipeIngredient1 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient1 };
            RecipeIngredient recipeIngredient2 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient2 };
            RecipeIngredient recipeIngredient3 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient3 };
            RecipeIngredient recipeIngredient4 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient4 };
            RecipeIngredient recipeIngredient5 = new RecipeIngredient { Recipe = recipe, Ingredient = ingredient5 };

            recipe.Ingredients.Add(recipeIngredient1);
            recipe.Ingredients.Add(recipeIngredient2);
            recipe.Ingredients.Add(recipeIngredient3);
            recipe.Ingredients.Add(recipeIngredient4);
            recipe.Ingredients.Add(recipeIngredient5);

            return recipes;
        }
    }
}
