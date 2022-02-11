using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class AppointmentServiceService : IAppointmentServiceService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AppointmentServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<int> CreateMany(List<AppointmentServiceDTO> appointmentList, int appointmentId)
        {
            List<int> createdIds = new List<int>();

            foreach (var appointment in appointmentList)
            {
                var mappedAppointment = _mapper.Map<AppointmentServiceDTO, Models.AppointmentService>(appointment);

                mappedAppointment.AppointmentId = appointmentId;

                var newAppointment = _unitOfWork.AppointmentServiceRepository.Add(mappedAppointment);
                createdIds.Add(newAppointment.Id);
            }


            _unitOfWork.Save();

            return createdIds;
        }
    }
}
