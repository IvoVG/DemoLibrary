using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Worker;
using DemoLibrary.Services.Worker;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoLibrary.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerService service;
        private readonly LibraryDbContext data;

        public WorkerController(IWorkerService service, LibraryDbContext data)
        {
            this.service = service;
            this.data = data;
        }

        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(WorkerAddModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (this.data.Workers.Any(x => x.Name == model.Name.TrimStart().TrimEnd()))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Това име вече съществува.");
            }

            if (this.service.IsWorker(userId) || this.User.IsInRole("Admin"))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Вече сте регистриран като работник.");
            }

            if (this.service.IsReader(userId) || this.User.IsInRole("Admin"))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Вече сте регистриран като читател.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var worker = new Worker
            {
                Name = model.Name.TrimStart().TrimEnd(),
                UserId = userId
            };

            this.data.Workers.Add(worker);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Workshop");
        }
    }
}
