namespace DentalManager.Application.Contracts.Appointments;

public interface IAppointmentServiceService
{
    List<int> CreateMany(List<AppointmentServiceDTO> appointmentList, int appointmentId);
    void DeleteAllByAppointmentId(int id);
    public List<AppointmentServiceDTO> UpdateMany(List<AppointmentServiceDTO> appService, int appointmentId);
}
