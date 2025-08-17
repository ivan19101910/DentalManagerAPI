using System.Threading;

namespace DentalManager.Application.Contracts.Days;

public interface IDayService
{
    List<DayDTO> GetAll();
    DayDTO GetById(int id);
    int Create(DayDTO serviceType, CancellationToken cancellationToken);
    DayDTO Update(DayDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
