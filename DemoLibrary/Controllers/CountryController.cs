using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Countries;
using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class CountryController : Controller
    {
        private readonly LibraryDbContext data;

        public CountryController(LibraryDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CountryAddModel model)
        {
            if (this.data.Countries.Any(x => x.Name == model.Name.TrimStart().TrimEnd()))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Country name already exist.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var country = new Country
            {
                Name = model.Name.TrimStart().TrimEnd()
            };

            this.data.Countries.Add(country);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Workshop");
        }
        }
}
