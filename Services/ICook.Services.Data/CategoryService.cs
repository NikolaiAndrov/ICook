namespace ICook.Services.Data
{
	using System.Collections.Generic;
	using System.Linq;

	using ICook.Data.Common.Repositories;
	using ICook.Data.Models;
	using ICook.Web.ViewModels.Category;

	public class CategoryService : ICategoryService
	{
		private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
			this.categoryRepository = categoryRepository;
		}

        public IEnumerable<CategoryViewModel> GetCategories()
		{
			IEnumerable<CategoryViewModel> categories = this.categoryRepository
				.AllAsNoTracking()
				.OrderBy(c => c.Name)
				.Select(c => new CategoryViewModel
				{
					Id = c.Id,
					Name = c.Name
				})
				.AsEnumerable();

			return categories;
		}
	}
}
