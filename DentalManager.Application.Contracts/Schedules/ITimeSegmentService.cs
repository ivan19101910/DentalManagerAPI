namespace DentalManager.Application.Contracts.Schedules;

public interface ITimeSegmentService
{
    List<TimeSegmentDTO> GetAll();
    TimeSegmentDTO GetById(int id);
    int Create(TimeSegmentDTO serviceType, CancellationToken cancellationToken);
    TimeSegmentDTO Update(TimeSegmentDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
