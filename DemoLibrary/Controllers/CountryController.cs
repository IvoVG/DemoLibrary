using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
