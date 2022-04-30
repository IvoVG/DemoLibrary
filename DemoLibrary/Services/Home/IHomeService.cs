using DemoLibrary.Services.Book;

namespace DemoLibrary.Services.Home
{
    public interface IHomeService
    {
        public bool IsReader(string userId);

        public IEnumerable<BookAllServicesModel> GetTop3();

        public int TotalBooks();
    }
}
