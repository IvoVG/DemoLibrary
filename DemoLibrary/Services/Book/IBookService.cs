namespace DemoLibrary.Services.Book
{
    public interface IBookService
    {
        IEnumerable<BookAllServicesModel> GetAll();
        BookDetailsServiceModel GetDetails(string bookId);
    }
}
