using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Add()
        {
            //var model = new AuthorAddModel
            //{
            //    Countries = this.GetAuthorCountry()
            //};
            return View();
        }
    }
}
