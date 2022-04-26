using DemoLibrary.Data;
using DemoLibrary.Services.Book;

namespace DemoLibrary.Services.Reader
{
    public class ReaderService : IReaderService
    {
        private readonly LibraryDbContext data;

        public ReaderService(LibraryDbContext data)
        {
            this.data = data;
        }

        public ReaderBookService GetBook(string bookId)
        {
            var book = this.data.Books.FirstOrDefault(b => b.Id == bookId);
            var authorName = GetAuthorFullName(bookId);
            var translatorName = GetTranslatorFullName(bookId);
            var categoryName = GetCategoryName(bookId);
            var countryName = GetCoutryName(bookId);
            var genreName = GetGenreName(bookId);

            var coments = book.Comments.Select(x => new ComentServiceModel
            {
                Id = x.Id,
                BookId = x.BookId,
                Description = x.Description,
                ReaderId = x.ReaderId
            }).ToList();

            var ratings = book.Ratings.Select(x => new RatingServiceModel
            {
                BookId = x.BookId,
                Evaluation = x.Evaluation,
                ReaderId = x.ReaderId,
                IsReadBook = x.IsReadBook
            }).ToList();

            var rating = ratings.Sum(c => c.Evaluation);
            if (ratings.Count == 0)
            {
                rating = 0;
            }
            else
            {
                rating = rating / ratings.Count;
            }

            var result = new ReaderBookService
            {
                AuthorFullName = authorName,
                TranslatorFullName = translatorName,
                CategoryName = categoryName,
                GenreName = genreName,
                CountryName = countryName,
                Ratings = ratings,
                Coments = coments,
                Rating = rating
            };
                

            return result;
        }

        public ReaderServiceView GetReaderModel(string userId, string bookId)
        {
            var reader = this.data.Readers.FirstOrDefault(x => x.UserId == userId);
            var books = this.data.ReadersBooks.Where(x => x.ReaderId == reader.Id).ToList();

            if (bookId == null)
            {
                if (books.Count() > 0)
                {
                    bookId = books.ElementAt(0).BookId;
                }
                else
                {
                    return null;
                }

            }

            var rating = this.data.Ratings.Where(x => x.BookId == bookId && x.ReaderId == reader.Id);
            var comment = this.data.Comments.Where(x => x.BookId == bookId && x.ReaderId == reader.Id);
            var book = GetBook(bookId);

            var data = new List<ReaderBookService>();

            foreach (var bookData in reader.Books)
            {
                data.Add(GetBook(bookData.BookId));
            }

            var model = new ReaderServiceView
            {
                ReaderId = reader.Id,
                UserId = userId,
                Name = reader.Name,
                Coments = reader.Coments,
                Ratings = reader.Ratings,
                BookId = bookId,
                Book = book,
                Books = data.ToList()
            };

            return model;
        }

        bool IReaderService.IsReader(string userId)
        {
            return this.data.Readers.Any(x => x.UserId == userId);
        }

        bool IReaderService.IsWorker(string userId)
        {
            return this.data.Workers.Any(x => x.UserId == userId);
        }

        private string GetAuthorFullName(string id)
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

        private string GetTranslatorFullName(string id)
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

        private string GetCategoryName(string id)
        {
            var book = data.Books.FirstOrDefault(x => x.Id == id);
            var categoryName = this.data.Categories.FirstOrDefault(c => c.Id == book.CategoryId);
            if (!string.IsNullOrEmpty(categoryName.Name))
            {
                return categoryName.Name;
            }

            return null;
        }

        private string GetCoutryName(string id)
        {
            var book = data.Books.FirstOrDefault(x => x.Id == id);
            var countryName = data.Countries.FirstOrDefault(c => c.Id == book.CountryId).Name;
            if (!string.IsNullOrEmpty(countryName))
            {
                return countryName;
            }

            return null;
        }

        private string GetGenreName(string id)
        {
            var book = data.Books.FirstOrDefault(x => x.Id == id);
            var genreName = this.data.Genres.FirstOrDefault(c => c.Id == book.GenreId).Name;
            if (!string.IsNullOrEmpty(genreName))
            {
                return genreName;
            }

            return null;
        }
    }
}
