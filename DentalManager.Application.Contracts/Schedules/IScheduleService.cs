namespace DentalManager.Application.Contracts.Schedules;

public interface IScheduleService
{
    List<ShowScheduleDTO> GetAll();
    ScheduleDTO GetById(int id);
    int Create(ScheduleDTO serviceType);
    ScheduleDTO Update(ScheduleDTO serviceType);
    void Delete(int id);
}
