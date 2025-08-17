using DentalManager.Domain.Workers;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Data.Workers;

internal sealed class WorkerScheduleRepository : RepositoryBase<WorkerSchedule>, IWorkerScheduleRepository
{
    public WorkerScheduleRepository(DentalManagerDBContext context) : base(context)
    {

    }

    public override WorkerSchedule GetById(int id)
    {
        return _context.WorkerSchedules
            .Where(x => x.Id == id)
            .FirstOrDefault();
    }

    public override IQueryable<WorkerSchedule> GetAll()
    {
        return base.GetAll()
            .Include(x => x.Worker)
            .Include(x => x.Schedule);
    }

    public List<WorkerSchedule> GetByWorkerId(int id)
    {
        return _context.WorkerSchedules.Where(x => x.WorkerId == id)
            .AsNoTracking()
            .ToList();
    }
}
