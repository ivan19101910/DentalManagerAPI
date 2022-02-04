using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ServiceTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceTypeDTO GetById(int id)
        {
            var serviceType = _unitOfWork.ServiceTypeRepository.GetById(id);

            var mappedService = _mapper.Map<ServiceTypeDTO>(serviceType);
            return mappedService;

        }

        public List<ServiceTypeDTO> GetAll()
        {
            var serviceTypes = _unitOfWork.ServiceTypeRepository.GetAll();
            var mappedList = _mapper.Map<List<ServiceType>, List<ServiceTypeDTO>>(serviceTypes.ToList());
            return mappedList;
        }

        public int Create(ServiceTypeDTO serviceType)
        {
            var mappedServiceType = _mapper.Map<ServiceTypeDTO, ServiceType>(serviceType);

            var newServiceType = _unitOfWork.ServiceTypeRepository.Add(mappedServiceType);
            _unitOfWork.Save();

            return newServiceType.Id;
        }

        public ServiceTypeDTO Update(ServiceTypeDTO serviceType)
        {
            var updateServiceType = _mapper.Map<ServiceType>(serviceType);
            var updatedServiceType = _unitOfWork.ServiceTypeRepository.Edit(updateServiceType);

            _unitOfWork.Save();

            var updatedServiceTypeDTO = _mapper.Map<ServiceTypeDTO>(updatedServiceType);

            return updatedServiceTypeDTO;
        }

        public void Delete(int id)
        {
            var serviceType = _unitOfWork.ServiceTypeRepository.GetById(id);
            if (serviceType != null)
            {
                _unitOfWork.ServiceTypeRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
