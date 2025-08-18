namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentPaymentService
{
    List<AppointmentPaymentDto> GetAll();
    AppointmentPaymentDto GetById(int id);
    int Create(AppointmentPaymentDto serviceType, CancellationToken cancellationToken);
    AppointmentPaymentDto Update(AppointmentPaymentDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
