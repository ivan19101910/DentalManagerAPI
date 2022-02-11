using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IOfficeService
    {
        List<ShowOfficeDTO> GetAll();
        OfficeDTO GetById(int id);
        int Create(OfficeDTO serviceType);
        OfficeDTO Update(OfficeDTO serviceType);
        void Delete(int id);
    }
}
