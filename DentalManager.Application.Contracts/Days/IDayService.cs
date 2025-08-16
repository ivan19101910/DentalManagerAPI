namespace DentalManager.Application.Contracts.Days;

public interface IDayService
{
    List<DayDTO> GetAll();
    DayDTO GetById(int id);
    int Create(DayDTO serviceType);
    DayDTO Update(DayDTO serviceType);
    void Delete(int id);
}
