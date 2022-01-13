using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IWorkerService
    {
        WorkerDTO GetWorkerById(int id);

        List<WorkerDTO> GetAll();
    }
}
