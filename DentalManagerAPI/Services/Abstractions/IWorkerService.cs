using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IWorkerService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        FullWorkerDTO GetWorkerById(int id);
        List<ShowWorkerDTO> GetAll();
        int Create(CreateWorkerDTO worker);
        UpdateWorkerDTO Update(UpdateWorkerDTO worker);
        void Delete(int id);
    }
}
