using DemoLibrary.Models.Book;
using DemoLibrary.Services.Book;
using Microsoft.AspNetCore.Mvc;

namespace DemoLibrary.Controllers
{
    public class BookController :Controller
    {
        private readonly IBookService services;

        public BookController(IBookService services)
        {
            this.services = services;
        }
        public IActionResult Add()=> View();

        [HttpPost]
        public IActionResult Add(AddBookModel book)
        {
            return View(book);
        }

        public IActionResult All(BookQueryServiceModel quary)
        {
            var result = this.services.GetAll();

            var model = new BookQueryServiceModel
            {
                Books = result,
                BooksPerPage = quary.BooksPerPage,
                CurrentPage = quary.CurrentPage,
                TotalBooks = quary.TotalBooks
            };

            return View(model);
        }
    }
}
