namespace ICook.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using ICook.Data;
    using ICook.Data.Models;
	using ICook.Data.Common.Repositories;

	[Area("Administration")]
    public class CategoriesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesController(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: Administration/Categories
        public async Task<IActionResult> Index()
        {
              return this.View(await this.categoryRepository
                  .AllAsNoTracking()
                  .ToListAsync());
        }

        // GET: Administration/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || this.categoryRepository.AllAsNoTracking() == null)
            {
                return this.NotFound();
            }

            var category = await this.categoryRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // GET: Administration/Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Category category)
        {
            if (this.ModelState.IsValid)
            {
                await this.categoryRepository.AddAsync(category);
                await this.categoryRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(category);
        }

        // GET: Administration/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || this.categoryRepository.AllAsNoTracking() == null)
            {
                return this.NotFound();
            }

            var category = await this.categoryRepository
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // POST: Administration/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Category category)
        {
            if (id != category.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.categoryRepository.Update(category);
                    await this.categoryRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await this.CategoryExists(category.Id) == false)
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(category);
        }

        // GET: Administration/Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || this.categoryRepository.AllAsNoTracking() == null)
            {
                return this.NotFound();
            }

            var category = await this.categoryRepository
                .All()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        // POST: Administration/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (this.categoryRepository.AllAsNoTracking() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }

            var category = await categoryRepository
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                categoryRepository.Delete(category);
            }
            
            await this.categoryRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoryExists(int id)
        {
          return await this.categoryRepository.AllAsNoTracking().AnyAsync(e => e.Id == id);
        }
    }
}
