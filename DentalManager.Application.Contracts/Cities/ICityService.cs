namespace DentalManager.Application.Contracts.Cities;

public interface ICityService
{
    List<CityDto> GetAll();
    CityDto GetById(int id);
    int Create(CityDto serviceType, CancellationToken cancellationToken);
    CityDto Update(CityDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
