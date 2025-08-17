namespace DentalManager.Application.Contracts.Positions;

public interface IPositionService
{
    List<PositionDTO> GetAll();
    PositionDTO GetById(int id);
    int Create(PositionDTO serviceType, CancellationToken cancellationToken);
    PositionDTO Update(PositionDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
