using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DentalManagerDBContext context) : base(context)
        {

        }

        public override IQueryable<Schedule> GetAll()
        {
            return base.GetAll().Include(x => x.Day).Include(x => x.TimeSegment);
        }
    }
}
