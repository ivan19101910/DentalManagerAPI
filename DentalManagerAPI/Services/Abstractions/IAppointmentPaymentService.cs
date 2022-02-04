using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IAppointmentPaymentService
    {
        List<AppointmentPaymentDTO> GetAll();
        AppointmentPaymentDTO GetById(int id);
        int Create(AppointmentPaymentDTO serviceType);
        AppointmentPaymentDTO Update(AppointmentPaymentDTO serviceType);
        void Delete(int id);
    }
}
