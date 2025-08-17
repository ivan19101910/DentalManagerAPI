namespace DentalManager.Application.Contracts.Workers;

public interface IWorkerScheduleService
{
    List<WorkerScheduleDTO> GetAll();

    WorkerScheduleDTO GetById(int id);

    int Create(WorkerScheduleDTO workerSchedule, CancellationToken cancellationToken);

    WorkerScheduleDTO Update(WorkerScheduleDTO workerSchedule, CancellationToken cancellationToken);

    List<WorkerScheduleDTO> UpdateMany(List<WorkerScheduleDTO> workerSchedules, int workerId, CancellationToken cancellationToken);

    void Delete(int id);

    void DeleteAllByWorkerId(int id);
}
