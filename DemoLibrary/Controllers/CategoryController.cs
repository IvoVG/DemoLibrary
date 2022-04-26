using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LibraryDbContext data;

        public CategoryController(LibraryDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddModel model)
        {
            if (this.data.Categories.Any(x => x.Name == model.Name.TrimStart().TrimEnd()))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Категорията вече съществува.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = new Category
            {
                Name = model.Name.TrimStart().TrimEnd()
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Workshop");
        }
    }
}
