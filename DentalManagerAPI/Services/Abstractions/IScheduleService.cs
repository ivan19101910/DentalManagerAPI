using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public class IScheduleService
    {
        List<ScheduleDTO> GetAll();
        ScheduleDTO GetById(int id);
        int Create(ScheduleDTO serviceType);
        ScheduleDTO Update(ScheduleDTO serviceType);
        void Delete(int id);
    }
}
