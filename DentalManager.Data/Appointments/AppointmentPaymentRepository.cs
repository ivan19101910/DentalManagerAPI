using DentalManager.Domain.Appointments;

namespace DentalManager.Data.Appointments;

internal sealed class AppointmentPaymentRepository : RepositoryBase<AppointmentPayment>, IAppointmentPaymentRepository
{
    public AppointmentPaymentRepository(DentalManagerDBContext context) : base(context)
    {

    }
}
