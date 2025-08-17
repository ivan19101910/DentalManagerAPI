using DentalManager.Application.Contracts.Services;
using DentalManager.Domain.Services;
using AutoMapper;

namespace DentalManager.Application.Services;

public sealed class ServiceTypeService : IServiceTypeService
{
    private readonly IServiceTypeRepository _serviceTypeRepository;

    private readonly IMapper _mapper;

    public ServiceTypeService(IServiceTypeRepository serviceTypeRepository, IMapper mapper)
    {
        _serviceTypeRepository = serviceTypeRepository;
        _mapper = mapper;
    }

    public ServiceTypeDTO GetById(int id)
    {
        var serviceType = _serviceTypeRepository.GetById(id);
        var mappedService = _mapper.Map<ServiceTypeDTO>(serviceType);

        return mappedService;
    }

    public List<ServiceTypeDTO> GetAll()
    {
        var serviceTypes = _serviceTypeRepository.GetAll();
        var mappedList = _mapper.Map<List<ServiceType>, List<ServiceTypeDTO>>(serviceTypes.ToList());

        return mappedList;
    }

    public int Create(ServiceTypeDTO serviceType, CancellationToken cancellationToken)
    {
        var mappedServiceType = _mapper.Map<ServiceTypeDTO, ServiceType>(serviceType);
        var newServiceType = _serviceTypeRepository.Add(mappedServiceType, cancellationToken);

        return newServiceType.Id;
    }

    public ServiceTypeDTO Update(ServiceTypeDTO serviceType, CancellationToken cancellationToken)
    {
        var updateServiceType = _mapper.Map<ServiceType>(serviceType);
        var updatedServiceType = _serviceTypeRepository.Update(updateServiceType, cancellationToken);
        var updatedServiceTypeDTO = _mapper.Map<ServiceTypeDTO>(updatedServiceType);

        return updatedServiceTypeDTO;
    }

    public void Delete(int id)
    {
        var serviceType = _serviceTypeRepository.GetById(id);

        if (serviceType != null)
        {
            _serviceTypeRepository.Delete(id);
        }
    }
}
