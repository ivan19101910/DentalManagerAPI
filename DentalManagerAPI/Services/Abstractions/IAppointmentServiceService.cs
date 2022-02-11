using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IAppointmentServiceService
    {
        List<int> CreateMany(List<AppointmentServiceDTO> appointmentList, int appointmentId);
    }
}
