using DentalManager.Domain.Appointments;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Data.Appointments;

internal sealed class AppointmentServiceRepository : BaseRepository<AppointmentService>, IAppointmentServiceRepository
{
    public AppointmentServiceRepository(DentalManagerDBContext context) : base(context)
    {

    }

    public List<AppointmentService> GetByAppointmentId(int id)
    {
        return _context.AppointmentServices.Where(x => x.AppointmentId == id)
            .AsNoTracking()
            .ToList();
    }

    public override AppointmentService Edit(AppointmentService entity)
    {
        _context.Entry(entity).State = EntityState.Detached;
        _context.Entry(entity).State = EntityState.Modified;

        return entity;
    }
}
