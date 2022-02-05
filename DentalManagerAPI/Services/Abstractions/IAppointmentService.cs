using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IAppointmentService
    {
        List<AppointmentDTO> GetAll();
        AppointmentDTO GetById(int id);
        int Create(AppointmentDTO serviceType);
        AppointmentDTO Update(AppointmentDTO serviceType);
        void Delete(int id);
    }
}
