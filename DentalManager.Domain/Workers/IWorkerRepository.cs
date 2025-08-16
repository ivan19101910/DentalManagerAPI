using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Workers;

public interface IWorkerRepository : IRepository<Worker>
{
    public Worker GetByEmailAndPassword(string email, string password);
    public Worker GetByIdWithAppointments(int id);
    public IQueryable<Worker> GetByNameSurname(string name, string surname);
    public IQueryable<Worker> GetByAddress(string city, string address);
}
