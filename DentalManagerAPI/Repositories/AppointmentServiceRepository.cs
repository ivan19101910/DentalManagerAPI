using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.Repositories
{
    public class AppointmentServiceRepository : BaseRepository<AppointmentService>, IAppointmentServiceRepository
    {
        public AppointmentServiceRepository(DentalManagerDBContext context) : base(context)
        {

        }

        public List<AppointmentService> GetByAppointmentId(int id)
        {
            return _context.AppointmentServices.Where(x => x.AppointmentId == id).AsNoTracking().ToList();
        }

        public override AppointmentService Edit(AppointmentService entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
