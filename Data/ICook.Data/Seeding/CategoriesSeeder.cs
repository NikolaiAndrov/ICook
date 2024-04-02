namespace ICook.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Categories.AnyAsync())
            {
                return;
            }

            ICollection<Category> categories = this.CreateCategories();
            await dbContext.Categories.AddRangeAsync(categories);

            await dbContext.SaveChangesAsync();
        }

        private ICollection<Category> CreateCategories()
        {
            ICollection<Category> categories = new List<Category>();

            Category category = new Category
            {
                Name = "Main Courses"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Pizza"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Burgers"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Starters"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Soups"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Desserts"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Fries"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Fish"
            };
            categories.Add(category);

            category = new Category
            {
                Name = "Vegan Courses"
            };
            categories.Add(category);

            return categories;
        }
    }
}
