namespace DentalManager.Application.Contracts.Services;

public interface IServiceTypeService
{
    List<ServiceTypeDTO> GetAll();
    ServiceTypeDTO GetById(int id);
    int Create(ServiceTypeDTO serviceType, CancellationToken cancellationToken);
    ServiceTypeDTO Update(ServiceTypeDTO serviceType, CancellationToken cancellationToken);
    void Delete(int id);
}
