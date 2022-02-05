using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IPositionService
    {
        List<PositionDTO> GetAll();
        PositionDTO GetById(int id);
        int Create(PositionDTO serviceType);
        PositionDTO Update(PositionDTO serviceType);
        void Delete(int id);
    }
}
