namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentPaymentService
{
    List<AppointmentPaymentDTO> GetAll();
    AppointmentPaymentDTO GetById(int id);
    int Create(AppointmentPaymentDTO serviceType, CancellationToken cancellationToken);
    AppointmentPaymentDTO Update(AppointmentPaymentDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
