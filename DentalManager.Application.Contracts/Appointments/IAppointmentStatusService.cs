namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentStatusService
{
    List<AppointmentStatusDTO> GetAll();
    AppointmentStatusDTO GetById(int id);
    int Create(AppointmentStatusDTO serviceType);
    AppointmentStatusDTO Update(AppointmentStatusDTO serviceType);
    void Delete(int id);
}
