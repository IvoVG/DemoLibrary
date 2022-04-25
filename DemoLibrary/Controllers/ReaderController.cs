using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Readers;
using DemoLibrary.Services.Reader;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoLibrary.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderService service;
        private readonly LibraryDbContext data;

        public ReaderController(IReaderService service, LibraryDbContext data)
        {
            this.service = service;
            this.data = data;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(ReaderAddModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (this.data.Readers.Any(x => x.Name == model.Name.TrimStart().TrimEnd()))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Това име вече съществува.");
            }
            if (this.service.IsReader(userId) || this.User.IsInRole("Admin"))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Вече сте регистриран като читател.");
            }
            if (this.service.IsWorker(userId)|| this.User.IsInRole("Admin"))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Вече сте регистриран като работник.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var reader = new Reader
            {
                Name = model.Name.TrimStart().TrimEnd(),
                UserId = userId,
                Books = new List<ReaderBook>(),
                Coments = new List<Comment>(),
                Ratings = new List<Rating>()
            };

            this.data.Readers.Add(reader);
            this.data.SaveChanges();

            return RedirectToAction("All", "Book");
        }

        public IActionResult Mine(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var book = this.data.Books.FirstOrDefault(b => b.Id == id);
            var model = this.service.GetReaderModel(userId, id);

            if (model == null)
            {
                return RedirectToAction("All", "Book");
            }

            return View(model);
        }
    }
}
