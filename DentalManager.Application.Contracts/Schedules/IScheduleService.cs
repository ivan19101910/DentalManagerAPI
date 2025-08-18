namespace DentalManager.Application.Contracts.Schedules;

public interface IScheduleService
{
    List<ShowScheduleDto> GetAll();
    ScheduleDto GetById(int id);
    int Create(ScheduleDto serviceType, CancellationToken cancellationToken);
    ScheduleDto Update(ScheduleDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
