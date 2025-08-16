using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Workers;

public interface IWorkerScheduleRepository : IRepository<WorkerSchedule>
{
    public List<WorkerSchedule> GetByWorkerId(int id);
}
