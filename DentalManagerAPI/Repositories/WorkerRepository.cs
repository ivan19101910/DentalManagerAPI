using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(DentalManagerDBContext context) : base(context)
        {

        }
        public Worker GetByEmailAndPassword(string email, string password)
        {
            var result = _context.Workers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            return result;
        }
    }
}
