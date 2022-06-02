using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IServiceService
    {
        List<ServiceDTO> GetAll();
        List<ServiceDTO> GetByServiceType(string serviceType);
        ServiceDTO GetById(int id);
        int Create(ServiceDTO serviceType);
        ServiceDTO Update(ServiceDTO serviceType);
        void Delete(int id);       
    }
}
