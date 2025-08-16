using DentalManager.Domain.Appointments;

namespace DentalManager.Data.Appointments;

internal sealed class AppointmentStatusRepository : BaseRepository<AppointmentStatus>, IAppointmentStatusRepository
{
    public AppointmentStatusRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
