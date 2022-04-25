using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class WorkshopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
