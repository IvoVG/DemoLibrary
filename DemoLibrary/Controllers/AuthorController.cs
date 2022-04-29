using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Author;
using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryDbContext data;

        public AuthorController(LibraryDbContext data)
        {
            this.data = data;
        }
        public IActionResult Add()
        {
            var model = new AuthorAddModel
            {
               Countries = this.GetAuthorCountry()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AuthorAddModel model)
        {
            if (this.data.Authors.Any(x => x.FirstName == model.FirstName.TrimStart().TrimEnd() && x.LastName == model.LastName.TrimStart().TrimEnd()))
            {
                this.ModelState.AddModelError(nameof(model.FirstName), "Името на автора вече съществува.");
                this.ModelState.AddModelError(nameof(model.LastName), "Името на автора вече съществува.");
            }

            if (this.GetAuthorCountry() == null)
            {
                this.ModelState.AddModelError(nameof(model.CountryId), "Няма Държава.");
            }
            if (!ModelState.IsValid)
            {
                model.Countries = this.GetAuthorCountry();

                return View(model);
            }

            var author = new Author
            {
                FirstName = model.FirstName.TrimStart().TrimEnd(),
                LastName = model.LastName.TrimStart().TrimEnd(),
                CountryId = model.CountryId
            };

            this.data.Authors.Add(author);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Workshop");
        }

        private IEnumerable<AuthorCountryViewModel> GetAuthorCountry()
        {
            return this.data.Countries
                .Select(t => new AuthorCountryViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();
        }
    }
}
