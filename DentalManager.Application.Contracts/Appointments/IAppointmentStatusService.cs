namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentStatusService
{
    List<AppointmentStatusDTO> GetAll();
    AppointmentStatusDTO GetById(int id);
    int Create(AppointmentStatusDTO serviceType, CancellationToken cancellationToken);
    AppointmentStatusDTO Update(AppointmentStatusDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
