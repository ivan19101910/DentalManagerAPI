using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Repositories
{
    public class WorkerScheduleRepository : BaseRepository<WorkerSchedule>, IWorkerScheduleRepository
    {
        public WorkerScheduleRepository(DentalManagerDBContext context) : base(context)
        {

        }

        public override WorkerSchedule GetById(int id)
        {
            var result = _context.WorkerSchedules.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
        public override IQueryable<WorkerSchedule> GetAll()
        {
            return base.GetAll().Include(x => x.Worker).Include(x => x.Schedule);
        }
        public List<WorkerSchedule> GetByWorkerId(int id)
        {
            return _context.WorkerSchedules.Where(x => x.WorkerId == id).AsNoTracking().ToList();
        }
    }
}
