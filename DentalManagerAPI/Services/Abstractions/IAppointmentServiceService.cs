using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IAppointmentServiceService
    {
        List<int> CreateMany(List<AppointmentServiceDTO> appointmentList, int appointmentId);
        void DeleteAllByAppointmentId(int id);
        public List<AppointmentServiceDTO> UpdateMany(List<AppointmentServiceDTO> appService, int appointmentId);
        //void UpdateMany(List<AppointmentServiceDTO>? appointmentServices);
    }
}
