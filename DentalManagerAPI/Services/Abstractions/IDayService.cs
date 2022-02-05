using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IDayService
    {
        List<DayDTO> GetAll();
        DayDTO GetById(int id);
        int Create(DayDTO serviceType);
        DayDTO Update(DayDTO serviceType);
        void Delete(int id);
    }
}
