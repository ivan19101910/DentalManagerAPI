using DentalManager.Domain.Schedules;

namespace DentalManager.Data.Schedules;

public class TimeSegmentRepository : RepositoryBase<TimeSegment>, ITimeSegmentRepository
{
    public TimeSegmentRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
