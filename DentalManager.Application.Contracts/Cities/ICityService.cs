namespace DentalManager.Application.Contracts.Cities;

public interface ICityService
{
    List<CityDTO> GetAll();
    CityDTO GetById(int id);
    int Create(CityDTO serviceType, CancellationToken cancellationToken);
    CityDTO Update(CityDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
