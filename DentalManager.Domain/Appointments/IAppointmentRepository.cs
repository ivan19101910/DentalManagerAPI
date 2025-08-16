using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Appointments;

public interface IAppointmentRepository : IRepository<Appointment>
{
    public IQueryable<Appointment> GetByWorkerId(int id);

    public IQueryable<Appointment> GetByWorkerId(int id, int monthNumber, int year);

    public IQueryable<Appointment> GetByPhoneNumber(string phoneNumber);

    public IQueryable<Appointment> GetByPatientId(int id);
}
