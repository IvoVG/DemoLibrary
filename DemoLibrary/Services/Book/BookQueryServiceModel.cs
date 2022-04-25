namespace DemoLibrary.Services.Book
{
    public class BookQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int BooksPerPage { get; set; }

        public int TotalBooks { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IEnumerable<BookAllServicesModel> Books { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
