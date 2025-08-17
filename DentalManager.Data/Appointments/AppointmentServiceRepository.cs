using DentalManager.Domain.Appointments;
using Microsoft.EntityFrameworkCore;

namespace DentalManager.Data.Appointments;

internal sealed class AppointmentServiceRepository : RepositoryBase<AppointmentService>, IAppointmentServiceRepository
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

    public override Task<AppointmentService> Update(AppointmentService entity, CancellationToken cancellationToken)
    {
        _context.Entry(entity).State = EntityState.Detached;
        _context.Entry(entity).State = EntityState.Modified;

        return Task.FromResult(entity);
    }
}
