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
    }
}
