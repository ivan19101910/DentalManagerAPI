namespace DentalManager.Application.Contracts.Services;

public interface IServiceService
{
    List<ServiceDTO> GetAll();
    List<ServiceDTO> GetByServiceType(string serviceType);
    ServiceDTO GetById(int id);
    int Create(ServiceDTO serviceType, CancellationToken cancellationToken);
    ServiceDTO Update(ServiceDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);       
}
