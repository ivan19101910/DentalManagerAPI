using DentalManagerAPI.Models;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        public Worker GetByEmailAndPassword(string email, string password);
        public Worker GetByIdWithAppointments(int id);
        public IQueryable<Worker> GetByNameSurname(string name, string surname);
        public IQueryable<Worker> GetByAddress(string city, string address);
    }
}
