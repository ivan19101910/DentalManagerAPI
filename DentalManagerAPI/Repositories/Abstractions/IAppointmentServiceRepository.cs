using DentalManagerAPI.Models;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IAppointmentServiceRepository : IRepository<AppointmentService>
    {
        public List<AppointmentService> GetByAppointmentId(int id);
    }
}
