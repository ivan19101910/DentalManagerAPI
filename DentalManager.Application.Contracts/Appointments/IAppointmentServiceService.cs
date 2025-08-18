namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentServiceService
{
    void DeleteAllByAppointmentId(int id);
    public List<AppointmentServiceDto> UpdateMany(List<AppointmentServiceDto> appService, int appointmentId, CancellationToken cancellationToken);
}
