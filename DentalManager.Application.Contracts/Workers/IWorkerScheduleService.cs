namespace DentalManager.Application.Contracts.Workers;

public interface IWorkerScheduleService
{
    List<WorkerScheduleDto> GetAll();

    WorkerScheduleDto GetById(int id);

    int Create(WorkerScheduleDto workerSchedule, CancellationToken cancellationToken);

    WorkerScheduleDto Update(WorkerScheduleDto workerSchedule, CancellationToken cancellationToken);

    List<WorkerScheduleDto> UpdateMany(List<WorkerScheduleDto> workerSchedules, int workerId, CancellationToken cancellationToken);

    void Delete(int id);

    void DeleteAllByWorkerId(int id);
}
