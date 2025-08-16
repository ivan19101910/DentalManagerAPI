using DentalManager.Application.Contracts.Services;
using DentalManager.Domain.Services;
using AutoMapper;

namespace DentalManager.Application.Services;

public sealed class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public ServiceDTO GetById(int id)
    {
        var service = _serviceRepository.GetById(id);
        var mappedService = _mapper.Map<ServiceDTO>(service);
        return mappedService;
    }

    public List<ServiceDTO> GetAll()
    {
        var services = _serviceRepository.GetAll();
        var mappedList = _mapper.Map<List<Service>, List<ServiceDTO>>(services.ToList());
        return mappedList;
    }
    public List<ServiceDTO> GetByServiceType(string serviceType)
    {
        var services = _serviceRepository.GetByServiceType(serviceType);
        var mappedList = _mapper.Map<List<Service>, List<ServiceDTO>>(services.ToList());
        return mappedList;
    }
    
    public int Create(ServiceDTO service)
    {
        var mappedService = _mapper.Map<ServiceDTO, Service>(service);
        var newService = _serviceRepository.Add(mappedService);
        return newService.Id;
    }

    public ServiceDTO Update(ServiceDTO service)
    {
        var updateService = _mapper.Map<Service>(service);
        var updatedService = _serviceRepository.Edit(updateService);
        var updatedServiceDTO = _mapper.Map<ServiceDTO>(updatedService);
        return updatedServiceDTO;
    }

    public void Delete(int id)
    {
        var service = _serviceRepository.GetById(id);
        if (service != null)
        {
            _serviceRepository.Delete(id);
        }
    }
}
