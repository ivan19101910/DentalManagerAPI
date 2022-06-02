using DentalManagerAPI.Models;

namespace DentalManagerAPI.Repositories.Abstractions
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public IQueryable<Appointment> GetByWorkerId(int id);
        public IQueryable<Appointment> GetByWorkerId(int id, int monthNumber, int year);
        public IQueryable<Appointment> GetByPhoneNumber(string phoneNumber);
        public IQueryable<Appointment> GetByPatientId(int id);
    }
}
