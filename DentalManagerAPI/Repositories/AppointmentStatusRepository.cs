using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class AppointmentStatusRepository : BaseRepository<AppointmentStatus>, IAppointmentStatusRepository
    {
        public AppointmentStatusRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
