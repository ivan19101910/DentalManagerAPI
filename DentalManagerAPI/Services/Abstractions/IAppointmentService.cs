using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IAppointmentService
    {
        List<ShortAppointmentDTO> GetAll();
        AppointmentDTO GetById(int id);
        int Create(CreateAppointmentDTO appointment);
        AppointmentDTO Update(AppointmentDTO appointment);
        void Delete(int id);
    }
}
