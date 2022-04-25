using DemoLibrary.Data;

namespace DemoLibrary.Services.Worker
{
    public class WorkerService : IWorkerService
    {
        private readonly LibraryDbContext data;

        public WorkerService(LibraryDbContext data)
        {
            this.data = data;
        }

        public bool IsReader(string userId)
        {
            return this.data.Readers.Any(x => x.UserId == userId);
        }

        public bool IsWorker(string userId)
        {
            return this.data.Workers.Any(x => x.UserId == userId);
        }
    }
}
