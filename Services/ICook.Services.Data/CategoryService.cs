namespace ICook.Services.Data
{
	using ICook.Data.Common.Repositories;
	using ICook.Data.Models;
	using ICook.Web.ViewModels.Category;
	using System.Collections.Generic;
	using System.Linq;

	public class CategoryService : ICategoryService
	{
		private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
			this.categoryRepository = categoryRepository;
		}

        public IEnumerable<CategoryViewModel> GetCategories()
		{
			IEnumerable<CategoryViewModel> categories = this.categoryRepository.AllAsNoTracking()
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
