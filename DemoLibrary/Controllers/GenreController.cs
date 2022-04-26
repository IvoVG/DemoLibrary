using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Genre;
using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class GenreController : Controller
    {
        private readonly LibraryDbContext data;

        public GenreController(LibraryDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(GenreAddModel model)
        {
            if (this.data.Genres.Any(x => x.Name == model.Name.TrimStart().TrimEnd()))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Genre already exist.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var genre = new Genre
            {
                Name = model.Name.TrimStart().TrimEnd()
            };

            this.data.Genres.Add(genre);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Workshop");
        }
    }
}
