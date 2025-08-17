namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentServiceService
{
    void DeleteAllByAppointmentId(int id);
    public List<AppointmentServiceDTO> UpdateMany(List<AppointmentServiceDTO> appService, int appointmentId, CancellationToken cancellationToken);
}
