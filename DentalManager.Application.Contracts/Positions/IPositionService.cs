namespace DentalManager.Application.Contracts.Positions;

public interface IPositionService
{
    List<PositionDto> GetAll();
    PositionDto GetById(int id);
    int Create(PositionDto serviceType, CancellationToken cancellationToken);
    PositionDto Update(PositionDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
