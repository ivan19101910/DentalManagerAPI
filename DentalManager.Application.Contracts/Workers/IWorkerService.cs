using DentalManagerAPI.Models;

namespace DentalManager.Application.Contracts.Workers;

public interface IWorkerService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    FullWorkerDto GetWorkerById(int id);
    List<ShowWorkerDto> GetAll();
    List<FullWorkerDto> GetWorkersByNameSurname(string name, string surname);
    List<FullWorkerDto> GetWorkersByAddress(string city, string address);
    int Create(CreateWorkerDto worker, CancellationToken cancellationToken);
    UpdateWorkerDto Update(UpdateWorkerDto worker, CancellationToken cancellationToken);
    void Delete(int id);
    public decimal CalculateSalaryByWorkerId(int workerId, int monthNumber, int year);
}
