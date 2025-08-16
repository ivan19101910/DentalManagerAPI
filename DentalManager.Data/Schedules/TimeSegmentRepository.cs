using DentalManager.Domain.Schedules;

namespace DentalManager.Data.Schedules;

public class TimeSegmentRepository : BaseRepository<TimeSegment>, ITimeSegmentRepository
{
    public TimeSegmentRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
