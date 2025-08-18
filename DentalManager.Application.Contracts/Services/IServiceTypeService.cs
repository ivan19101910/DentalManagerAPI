namespace DentalManager.Application.Contracts.Services;

public interface IServiceTypeService
{
    List<ServiceTypeDto> GetAll();
    ServiceTypeDto GetById(int id);
    int Create(ServiceTypeDto serviceType, CancellationToken cancellationToken);
    ServiceTypeDto Update(ServiceTypeDto serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
