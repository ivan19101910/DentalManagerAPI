using DentalManagerAPI.DAL;
using DentalManagerAPI.Models;
using DentalManagerAPI.Repositories.Abstractions;

namespace DentalManagerAPI.Repositories
{
    public class AppointmentServiceRepository : BaseRepository<AppointmentService>, IAppointmentServiceRepository
    {
        public AppointmentServiceRepository(DentalManagerDBContext context) : base(context)
        {

        }
    }
}
