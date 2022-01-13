using DentalManagerAPI.Models;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IWorkerRepository : IRepository<Worker>
    {
        public Worker GetByEmailAndPassword(string email, string password);
    }
}
