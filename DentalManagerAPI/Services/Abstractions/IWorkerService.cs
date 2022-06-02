using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IWorkerService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        FullWorkerDTO GetWorkerById(int id);
        List<ShowWorkerDTO> GetAll();
        List<FullWorkerDTO> GetWorkersByNameSurname(string name, string surname);
        List<FullWorkerDTO> GetWorkersByAddress(string city, string address);
        int Create(CreateWorkerDTO worker);
        UpdateWorkerDTO Update(UpdateWorkerDTO worker);
        void Delete(int id);
        public decimal CalculateSalaryByWorkerId(int workerId, int monthNumber, int year);
    }
}
