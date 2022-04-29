using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using DemoLibrary.Models.Book;
using DemoLibrary.Services.Book;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DemoLibrary.Controllers
{
    public class BookController :Controller
    {
        private readonly IBookService services;
        private readonly LibraryDbContext data;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnv;

        [Obsolete]
        public BookController(IBookService services, LibraryDbContext data, IHostingEnvironment hostingEnv)
        {
            this.services = services;
            this.data = data;
            this.hostingEnv = hostingEnv;
        }
        public IActionResult Add()
        {
            var model = new AddBookModel
            {
                Countries = this.GetCountry(),
                Genres = this.GetGenre(),
                Categories = this.GetCategory()
            };
            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Add([FromForm] AddBookModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var worker = this.data.Workers.FirstOrDefault(x => x.UserId == userId);
            var author = GetAuthor(model.AuthorFirstName.TrimStart().TrimEnd(), model.AuthorLastName.TrimStart().TrimEnd());
            var translator = GetTranslator(model.TranslatorFirstName.TrimStart().TrimEnd(), model.TranslatorLastName.TrimStart().TrimEnd());

            if (this.data.Books.Any(b => b.Title == model.Title.TrimStart().TrimEnd() && b.AuthorId == author.Id))
            {
                this.ModelState.AddModelError(nameof(model.Title), "Книгата вече съществува.");
            }

            if (author == null)
            {
                this.ModelState.AddModelError(nameof(model.AuthorFirstName), "Автора не съществува.");
                this.ModelState.AddModelError(nameof(model.AuthorLastName), "Въведете първо автора");
            }

            if (translator == null)
            {
                this.ModelState.AddModelError(nameof(model.TranslatorFirstName), "Преводача не съществува.");
                this.ModelState.AddModelError(nameof(model.TranslatorLastName), "Въведете първо преводача");
            }

            if (model.CreateYear > 2022)
            {
                this.ModelState.AddModelError(nameof(model.CreateYear), "Грешна година.");
            }

            if (model.Summary != null && model.Summary.Length > 1000)
            {
                this.ModelState.AddModelError(nameof(model.Summary), "Текста е по голям от 1000 знака.");
            }

            if (model.Series != null && model.Series.Length > 250)
            {
                this.ModelState.AddModelError(nameof(model.Series), "Текста е по голям от 250 знака.");
            }

            if (model.CoverUrl == null)
            {
                this.ModelState.AddModelError(nameof(model.CoverUrl), "Няма прикачен файл");
            }

            if (model.Address == null)
            {
                this.ModelState.AddModelError(nameof(model.Address), "Няма прикачен файл");
            }

            if (worker == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                model.Countries = this.GetCountry();
                model.Genres = GetGenre();
                model.Categories = GetCategory();

                return View(model);
            }

            if (model.CoverUrl != null || model.Address != null)
            {
                var a = hostingEnv.WebRootPath;
                var fileName1 = Path.GetFileName(model.CoverUrl.FileName);
                var fileName2 = Path.GetFileName(model.Address.FileName);
                var filePath1 = Path.Combine(hostingEnv.WebRootPath, "/Images", fileName1);
                var filePath2 = Path.Combine(hostingEnv.WebRootPath, @"C:\SoftUni\MyLibrary\books", fileName2);

                using (var fileSteam = new FileStream(filePath1, FileMode.Create))
                {
                    await model.CoverUrl.CopyToAsync(fileSteam);
                }

                using (var fileSteam = new FileStream(filePath2, FileMode.Create))
                {
                    await model.Address.CopyToAsync(fileSteam);
                }

                var book = new Book
                {
                    Title = model.Title.TrimStart().TrimEnd(),
                    CreateYear = model.CreateYear,
                    Uploaded = System.DateTime.Now,
                    Summary = model.Summary,
                    Series = model.Series,
                    GenreId = model.GenreId,
                    CategoryId = model.CategoryId,
                    CountryId = model.CountryId,
                    CoverPath = filePath1,
                    Address = filePath2,
                    Downloads = 0,
                    AuthorId = author.Id,
                    TranslatorId = translator.Id,
                    Ratings = new List<Rating>(),
                    Comments = new List<Comment>()
                };

                author.Books.Add(book);
                translator.Books.Add(book);
                worker.Books.Add(book);
                data.Books.Add(book);
                await data.SaveChangesAsync();
                // return Ok();
                return RedirectToAction("Index", "Workshop");
            }
            else
            {
                return BadRequest();
            }
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

        private Author GetAuthor(string firstName, string lastName)
        {
            return data.Authors
                .Where(a => a.FirstName == firstName && a.LastName == lastName)
                .FirstOrDefault();
        }

        private Translator GetTranslator(string firstName, string lastName)
        {
            return data.Translators
                .Where(a => a.FirstName == firstName && a.LastName == lastName)
                .FirstOrDefault();
        }

        private IEnumerable<BookCategoryViewModel> GetCategory()
        {
            return this.data.Categories
                .Select(c => new BookCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ToList();
        }

        private IEnumerable<BookGenreViewModel> GetGenre()
        {
            return this.data.Genres
                .Select(g => new BookGenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .OrderBy(c => c.Name)
                .ToList();
        }

        private IEnumerable<BookCountryViewModel> GetCountry()
        {
            return this.data.Countries
                .Select(c => new BookCountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}
