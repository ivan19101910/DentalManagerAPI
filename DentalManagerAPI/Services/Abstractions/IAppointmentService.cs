using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IAppointmentService
    {
        List<ShortAppointmentDTO> GetAll();
        FullAppointmentDTO GetById(int id);
        List<FullAppointmentDTO> GetByWorkerId(int id);
        List<FullAppointmentDTO> GetByPatientId(int id);
        int Create(CreateAppointmentDTO appointment);
        EditAppointmentDTO Update(EditAppointmentDTO appointment);
        void Delete(int id);
    }
}
