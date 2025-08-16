namespace DentalManager.Application.Contracts.Positions;

public interface IPositionService
{
    List<PositionDTO> GetAll();
    PositionDTO GetById(int id);
    int Create(PositionDTO serviceType);
    PositionDTO Update(PositionDTO serviceType);
    void Delete(int id);
}
