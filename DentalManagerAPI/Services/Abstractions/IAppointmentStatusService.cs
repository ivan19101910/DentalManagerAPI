using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IAppointmentStatusService
    {
        List<AppointmentStatusDTO> GetAll();
        AppointmentStatusDTO GetById(int id);
        int Create(AppointmentStatusDTO serviceType);
        AppointmentStatusDTO Update(AppointmentStatusDTO serviceType);
        void Delete(int id);
    }
}
