using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class TimeSegmentRepository : BaseRepository<TimeSegment>, ITimeSegmentRepository
    {
        public TimeSegmentRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
