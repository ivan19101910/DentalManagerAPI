namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentService
{
    List<ShortAppointmentDto> GetAll();
    FullAppointmentDto GetById(int id);
    List<FullAppointmentDto> GetByWorkerId(int id);
    List<FullAppointmentDto> GetByPatientId(int id);
    List<FullAppointmentDto> GetByPhoneNumber(string phoneNumber);
    int Create(CreateAppointmentDto appointment, CancellationToken cancellationToken);
    EditAppointmentDto Update(EditAppointmentDto appointment, CancellationToken cancellationToken);
    void Delete(int id);
}
