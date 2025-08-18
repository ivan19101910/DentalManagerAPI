namespace DentalManager.Application.Contracts.Services;

public interface IServiceService
{
    List<ServiceDto> GetAll();
    List<ServiceDto> GetByServiceType(string serviceType);
    ServiceDto GetById(int id);
    int Create(ServiceDto serviceType, CancellationToken cancellationToken);
    ServiceDto Update(ServiceDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);       
}
