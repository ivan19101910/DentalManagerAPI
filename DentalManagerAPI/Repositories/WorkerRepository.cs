using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

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
        public override IQueryable<Worker> GetAll()
        {
            return base.GetAll().Include(x => x.Office).ThenInclude(x => x.City).Include(x => x.Position);
        }
        
        public override Worker GetById(int id)
        {
            return _context.Workers.Where(x => x.Id == id)
                .Include(x => x.Office)
                .ThenInclude(x => x.City)
                .Include(x => x.Position)
                .Include(x => x.WorkerSchedules)
                .ThenInclude(x => x.Schedule)
                .ThenInclude(x => x.Day)
                .Include(x => x.WorkerSchedules)
                .ThenInclude(x => x.Schedule)
                .ThenInclude(x => x.TimeSegment)
                .FirstOrDefault();
        }

    }
}
