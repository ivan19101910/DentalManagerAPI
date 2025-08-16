using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Appointments;

public interface IAppointmentServiceRepository : IRepository<AppointmentService>
{
    public List<AppointmentService> GetByAppointmentId(int id);
}
