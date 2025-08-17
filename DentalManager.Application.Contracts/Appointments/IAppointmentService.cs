namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentService
{
    List<ShortAppointmentDTO> GetAll();
    FullAppointmentDTO GetById(int id);
    List<FullAppointmentDTO> GetByWorkerId(int id);
    List<FullAppointmentDTO> GetByPatientId(int id);
    List<FullAppointmentDTO> GetByPhoneNumber(string phoneNumber);
    int Create(CreateAppointmentDTO appointment, CancellationToken cancellationToken);
    EditAppointmentDTO Update(EditAppointmentDTO appointment, CancellationToken cancellationToken);
    void Delete(int id);
}
