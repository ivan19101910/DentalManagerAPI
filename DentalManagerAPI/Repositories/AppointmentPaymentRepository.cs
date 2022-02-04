using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class AppointmentPaymentRepository : BaseRepository<AppointmentPayment>, IAppointmentPaymentRepository
    {
        public AppointmentPaymentRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
