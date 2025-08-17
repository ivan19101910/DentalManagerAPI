using DentalManager.Domain.Schedules;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Data.Schedules;

internal sealed class ScheduleRepository : RepositoryBase<Schedule>, IScheduleRepository
{
    public ScheduleRepository(DentalManagerDBContext context) : base(context)
    {

    }

    public override IQueryable<Schedule> GetAll()
    {
        return base.GetAll()
            .Include(x => x.Day)
            .Include(x => x.TimeSegment);
    }
}
