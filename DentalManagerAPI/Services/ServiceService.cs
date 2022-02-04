using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class ServiceService : IServiceService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ServiceDTO GetById(int id)
        {
            var service = _unitOfWork.ServiceRepository.GetById(id);

            var mappedService = _mapper.Map<ServiceDTO>(service);
            return mappedService;

        }

        public List<ServiceDTO> GetAll()
        {
            var services = _unitOfWork.ServiceRepository.GetAll();
            var mappedList = _mapper.Map<List<Service>, List<ServiceDTO>>(services.ToList());
            return mappedList;
        }

        public int Create(ServiceDTO service)
        {
            var mappedService = _mapper.Map<ServiceDTO, Service>(service);

            var newService = _unitOfWork.ServiceRepository.Add(mappedService);
            _unitOfWork.Save();

            return newService.Id;
        }

        public ServiceDTO Update(ServiceDTO service)
        {
            var updateService = _mapper.Map<Service>(service);
            var updatedService = _unitOfWork.ServiceRepository.Edit(updateService);

            _unitOfWork.Save();

            var updatedServiceDTO = _mapper.Map<ServiceDTO>(updatedService);

            return updatedServiceDTO;
        }

        public void Delete(int id)
        {
            var service = _unitOfWork.ServiceRepository.GetById(id);
            if (service != null)
            {
                _unitOfWork.ServiceRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
