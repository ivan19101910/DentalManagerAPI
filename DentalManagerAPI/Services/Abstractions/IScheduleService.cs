using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IScheduleService
    {
        List<ShowScheduleDTO> GetAll();
        ScheduleDTO GetById(int id);
        int Create(ScheduleDTO serviceType);
        ScheduleDTO Update(ScheduleDTO serviceType);
        void Delete(int id);
    }
}
