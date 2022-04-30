using DemoLibrary.Data;

namespace DemoLibrary.Services.Book
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext data;

        public BookService(LibraryDbContext data)
        {
            this.data=data;
        }

        public BookDetailsServiceModel GetDetails(string bookId)
        {
                var authorFullName = GetAuthorFullName(bookId);
                var translatorFullName = GetTranslatorFullName(bookId);
                var book = this.data.Books.FirstOrDefault(x => x.Id == bookId);
                var model = new BookDetailsServiceModel
                {
                    Id = book.Id,
                    AuthorFullName = authorFullName,
                    Category = book.Category,
                    Country = book.Country,
                    CreateYear = book.CreateYear,
                    Address = Path.GetFileName(Path.Combine(@"C:\SoftUni\DemoLibrary\books", book.Address)),
                    Downloads = book.Downloads,
                    Genre = book.Genre,
                    Improved = book.Improved,
                    CoverPath = Path.GetFileName(Path.Combine("/Covers/images/", book.CoverPath)),
                    Series = book.Series,
                    Summary = book.Summary,
                    Title = book.Title,
                    TranslatorFullName = translatorFullName,
                    Uploaded = book.Uploaded
                };

                return model;
        }

        IEnumerable<BookAllServicesModel> IBookService.GetAll()
        {
            return this.data.Books.Select(b => new BookAllServicesModel
            {
                Id = b.Id,
                CategoryId = b.CategoryId,
                CountryId = b.CountryId,
                CreateYear = b.CreateYear,
                GenreId = b.GenreId,
                Series = b.Series,
                Improved = b.Improved,
                Title = b.Title,
                CoverPath = Path.GetFileName(Path.GetFullPath(b.CoverPath)),
                Address = b.Address,
                Summary = b.Summary,
                Uploaded = b.Uploaded,
                Downloads = b.Downloads,
            }).
            ToList();
        }

        public string GetAuthorFullName(string id)
        {
            var book = data.Books.FirstOrDefault(x => x.Id == id);
            var author = data.Authors.FirstOrDefault(x => x.Books.Contains(book));
            if (author != null)
            {
                var fullName = author.FirstName + " " + author.LastName;

                return fullName;
            }

            return null;
        }

        public string GetTranslatorFullName(string id)
        {
            var book = data.Books.FirstOrDefault(x => x.Id == id);
            var translator = data.Translators.FirstOrDefault(x => x.Books.Contains(book));
            if (translator != null)
            {
                var fullName = translator.FirstName + " " + translator.LastName;

                return fullName;
            }

            return null;
        }
    }
}
