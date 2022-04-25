namespace DemoLibrary.Services.Reader
{
    public interface IReaderService
    {
        public bool IsReader(string userId);

        public bool IsWorker(string userId);
    }
}
