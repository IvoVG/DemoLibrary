using DemoLibrary.Services.Book;

namespace DemoLibrary.Services.Home
{
    public class HomeBooksTopService
    {
        public int TotalBooks { get; set; }

        public IEnumerable<BookAllServices>? Books { get; set; }
    }
}
