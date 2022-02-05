using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AppointmentDTO GetById(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public List<AppointmentDTO> GetAll()
        {
            var appointments = _unitOfWork.AppointmentRepository.GetAll();
            return _mapper.Map<List<Appointment>, List<AppointmentDTO>>(appointments.ToList());          
        }

        public int Create(AppointmentDTO appointment)
        {
            var mappedAppointment = _mapper.Map<AppointmentDTO, Appointment>(appointment);

            var newAppointment = _unitOfWork.AppointmentRepository.Add(mappedAppointment);
            _unitOfWork.Save();

            return newAppointment.Id;
        }

        public AppointmentDTO Update(AppointmentDTO appointment)
        {
            var updateAppointment = _mapper.Map<Appointment>(appointment);
            var updatedAppointment = _unitOfWork.AppointmentRepository.Edit(updateAppointment);

            _unitOfWork.Save();

            return _mapper.Map<AppointmentDTO>(updatedAppointment);       
        }

        public void Delete(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);
            if (appointment != null)
            {
                _unitOfWork.AppointmentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
