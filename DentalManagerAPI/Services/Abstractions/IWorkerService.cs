using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IWorkerService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        WorkerDTO GetWorkerById(int id);

        List<WorkerDTO> GetAll();
    }
}
