namespace DemoLibrary.Services.Reader
{
    public interface IReaderService
    {
        public bool IsReader(string userId);

        public bool IsWorker(string userId);

        public ReaderBookService GetBook(string bookId);

        public ReaderServiceView GetReaderModel(string userId, string bookId);
    }
}
