using System.Threading;

namespace DentalManager.Application.Contracts.Days;

public interface IDayService
{
    List<DayDto> GetAll();
    DayDto GetById(int id);
    int Create(DayDto serviceType, CancellationToken cancellationToken);
    DayDto Update(DayDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
