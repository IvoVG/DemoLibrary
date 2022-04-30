using DemoLibrary.Data;
using DemoLibrary.Services.Book;

namespace DemoLibrary.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly LibraryDbContext data;

        public HomeService(LibraryDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<BookAllServicesModel> GetTop3()
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
                CoverPath = Path.GetFileName(Path.Combine("/Covers/images/", b.CoverPath)),
                Address = b.Address,
                Summary = b.Summary,
                Uploaded = b.Uploaded,
                Downloads = b.Downloads
            })
            .OrderBy(x => x.Uploaded)
            .Take(3)
            .ToList();
        }


        public bool IsReader(string userId)
        {
            return this.data
                .Readers.
                Any(r => r.UserId == userId);
        }

        public int TotalBooks()
        {
            return this.data.Books.Count();
        }
     }
}
