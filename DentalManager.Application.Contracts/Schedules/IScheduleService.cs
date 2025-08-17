namespace DentalManager.Application.Contracts.Schedules;

public interface IScheduleService
{
    List<ShowScheduleDTO> GetAll();
    ScheduleDTO GetById(int id);
    int Create(ScheduleDTO serviceType, CancellationToken cancellationToken);
    ScheduleDTO Update(ScheduleDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
