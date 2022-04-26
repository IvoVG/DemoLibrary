using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Translator;
using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly LibraryDbContext data;

        public TranslatorController(LibraryDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            var model = new TranslatorAddModel
            {
                Countries = this.GetTranslatorCountry()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TranslatorAddModel model)
        {
            if (this.data.Translators.Any(x => x.FirstName == model.FirstName.TrimStart().TrimEnd() && x.LastName == model.LastName.TrimStart().TrimEnd()))
            {
                this.ModelState.AddModelError(nameof(model.FirstName), "Името на преводача вече съществува.");
                this.ModelState.AddModelError(nameof(model.LastName), "Името на преводача вече съществува.");
            }

            if (!ModelState.IsValid)
            {
                model.Countries = this.GetTranslatorCountry();

                return View(model);
            }

            var translator = new Translator
            {
                FirstName = model.FirstName.TrimStart().TrimEnd(),
                LastName = model.LastName.TrimStart().TrimEnd(),
                CountryId = model.CountryId
            };

            this.data.Translators.Add(translator);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Workshop");
        }

        private IEnumerable<TranslatorCountryViewModel> GetTranslatorCountry()
        {
            return this.data.Countries
                .Select(t => new TranslatorCountryViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();
        }
    }
}
