using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class ScheduleService : IScheduleService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ScheduleDTO GetById(int id)
        {
            var schedule = _unitOfWork.ScheduleRepository.GetById(id);

            return _mapper.Map<ScheduleDTO>(schedule);
        }

        public List<ScheduleDTO> GetAll()
        {
            var schedules = _unitOfWork.ScheduleRepository.GetAll();
            return _mapper.Map<List<Schedule>, List<ScheduleDTO>>(schedules.ToList());
        }

        public int Create(ScheduleDTO schedule)
        {
            var mappedSchedule = _mapper.Map<ScheduleDTO, Schedule>(schedule);

            var newSchedule = _unitOfWork.ScheduleRepository.Add(mappedSchedule);
            _unitOfWork.Save();

            return newSchedule.Id;
        }

        public ScheduleDTO Update(ScheduleDTO schedule)
        {
            var updateSchedule = _mapper.Map<Schedule>(schedule);
            var updatedSchedule = _unitOfWork.ScheduleRepository.Edit(updateSchedule);

            _unitOfWork.Save();

            var updatedScheduleDTO = _mapper.Map<ScheduleDTO>(updatedSchedule);

            return updatedScheduleDTO;
        }

        public void Delete(int id)
        {
            var schedule = _unitOfWork.ScheduleRepository.GetById(id);
            if (schedule != null)
            {
                _unitOfWork.ScheduleRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
