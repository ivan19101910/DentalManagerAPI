using DentalManager.Domain.Appointments;

namespace DentalManager.Data.Appointments;

internal sealed class AppointmentStatusRepository : RepositoryBase<AppointmentStatus>, IAppointmentStatusRepository
{
    public AppointmentStatusRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
