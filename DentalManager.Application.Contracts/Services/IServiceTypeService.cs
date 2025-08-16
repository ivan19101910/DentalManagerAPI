namespace DentalManager.Application.Contracts.Services;

public interface IServiceTypeService
{
    List<ServiceTypeDTO> GetAll();
    ServiceTypeDTO GetById(int id);
    int Create(ServiceTypeDTO serviceType);
    ServiceTypeDTO Update(ServiceTypeDTO serviceType);
    void Delete(int id);
}
