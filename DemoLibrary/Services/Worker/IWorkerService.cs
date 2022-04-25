namespace DemoLibrary.Services.Worker
{
    public interface IWorkerService
    {
        public bool IsReader(string userId);

        public bool IsWorker(string userId);
    }
}
