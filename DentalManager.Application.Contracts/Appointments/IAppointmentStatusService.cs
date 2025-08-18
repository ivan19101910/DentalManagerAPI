namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentStatusService
{
    List<AppointmentStatusDto> GetAll();
    AppointmentStatusDto GetById(int id);
    int Create(AppointmentStatusDto serviceType, CancellationToken cancellationToken);
    AppointmentStatusDto Update(AppointmentStatusDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
