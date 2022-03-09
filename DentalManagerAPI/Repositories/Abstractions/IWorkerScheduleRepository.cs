using DentalManagerAPI.Models;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IWorkerScheduleRepository : IRepository<WorkerSchedule>
    {
        public List<WorkerSchedule> GetByWorkerId(int id);
    }
}
