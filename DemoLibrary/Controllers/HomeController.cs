using DemoLibrary.Models;
using DemoLibrary.Services.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService service;

        public HomeController(ILogger<HomeController> logger, IHomeService service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Index()
        {
            var queri = new HomeBooksTopService
            {
                TotalBooks = this.service.TotalBooks(),
                Books = this.service.GetTop3()
            };
            return View(queri);
        }

       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}