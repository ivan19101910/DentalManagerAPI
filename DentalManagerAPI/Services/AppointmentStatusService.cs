using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class AppointmentStatusService : IAppointmentStatusService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AppointmentStatusDTO GetById(int id)
        {
            var status = _unitOfWork.AppointmentStatusRepository.GetById(id);

            var mappedStatus = _mapper.Map<AppointmentStatusDTO>(status);
            return mappedStatus;

        }

        public List<AppointmentStatusDTO> GetAll()
        {
            var statuses = _unitOfWork.AppointmentStatusRepository.GetAll();
            var mappedList = _mapper.Map<List<AppointmentStatus>, List<AppointmentStatusDTO>>(statuses.ToList());
            return mappedList;
        }

        public int Create(AppointmentStatusDTO status)
        {
            var mappedStatus = _mapper.Map<AppointmentStatusDTO, AppointmentStatus>(status);

            var newStatus = _unitOfWork.AppointmentStatusRepository.Add(mappedStatus);
            _unitOfWork.Save();

            return newStatus.Id;
        }

        public AppointmentStatusDTO Update(AppointmentStatusDTO status)
        {
            var updateStatus = _mapper.Map<AppointmentStatus>(status);
            var updatedStatus = _unitOfWork.AppointmentStatusRepository.Edit(updateStatus);

            _unitOfWork.Save();

            var updatedStatusDTO = _mapper.Map<AppointmentStatusDTO>(updatedStatus);

            return updatedStatusDTO;
        }

        public void Delete(int id)
        {
            var status = _unitOfWork.AppointmentStatusRepository.GetById(id);
            if (status != null)
            {
                _unitOfWork.AppointmentStatusRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
