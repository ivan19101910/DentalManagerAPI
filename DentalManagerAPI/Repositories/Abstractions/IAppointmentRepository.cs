using DentalManagerAPI.Models;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public IQueryable<Appointment> GetByWorkerId(int id);
        public IQueryable<Appointment> GetByPatientId(int id);
    }
}
