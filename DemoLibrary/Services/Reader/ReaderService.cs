using DemoLibrary.Data;

namespace DemoLibrary.Services.Reader
{
    public class ReaderService : IReaderService
    {
        private readonly LibraryDbContext data;

        public ReaderService(LibraryDbContext data)
        {
            this.data = data;
        }

        bool IReaderService.IsReader(string userId)
        {
            return this.data.Readers.Any(x => x.UserId == userId);
        }

        bool IReaderService.IsWorker(string userId)
        {
            return this.data.Workers.Any(x => x.UserId == userId);
        }
    }
}
