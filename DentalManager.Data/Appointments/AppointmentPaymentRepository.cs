using DentalManager.Domain.Appointments;

namespace DentalManager.Data.Appointments;

internal sealed class AppointmentPaymentRepository : BaseRepository<AppointmentPayment>, IAppointmentPaymentRepository
{
    public AppointmentPaymentRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
