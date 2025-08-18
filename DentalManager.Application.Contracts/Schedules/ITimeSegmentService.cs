namespace DentalManager.Application.Contracts.Schedules;

public interface ITimeSegmentService
{
    List<TimeSegmentDto> GetAll();
    TimeSegmentDto GetById(int id);
    int Create(TimeSegmentDto serviceType, CancellationToken cancellationToken);
    TimeSegmentDto Update(TimeSegmentDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
