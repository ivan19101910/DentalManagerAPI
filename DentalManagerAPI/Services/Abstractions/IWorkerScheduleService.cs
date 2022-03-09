using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IWorkerScheduleService
    {
        List<WorkerScheduleDTO> GetAll();
        WorkerScheduleDTO GetById(int id);
        int Create(WorkerScheduleDTO workerSchedule);
        WorkerScheduleDTO Update(WorkerScheduleDTO workerSchedule);
        List<WorkerScheduleDTO> UpdateMany(List<WorkerScheduleDTO> workerSchedules, int workerId);
        void Delete(int id);
        void DeleteAllByWorkerId(int id);
    }
}
