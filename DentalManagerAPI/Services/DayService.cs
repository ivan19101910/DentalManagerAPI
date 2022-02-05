using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class DayService : IDayService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DayService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public DayDTO GetById(int id)
        {
            var day = _unitOfWork.DayRepository.GetById(id);

            return _mapper.Map<DayDTO>(day);
        }

        public List<DayDTO> GetAll()
        {
            var days = _unitOfWork.DayRepository.GetAll();
            return _mapper.Map<List<Day>, List<DayDTO>>(days.ToList());
        }

        public int Create(DayDTO day)
        {
            var mappedDay = _mapper.Map<DayDTO, Day>(day);

            var newDay = _unitOfWork.DayRepository.Add(mappedDay);
            _unitOfWork.Save();

            return newDay.Id;
        }

        public DayDTO Update(DayDTO day)
        {
            var updateDay = _mapper.Map<Day>(day);
            var updatedDay = _unitOfWork.DayRepository.Edit(updateDay);

            _unitOfWork.Save();

            var updatedDayDTO = _mapper.Map<DayDTO>(updatedDay);

            return updatedDayDTO;
        }

        public void Delete(int id)
        {
            var day = _unitOfWork.DayRepository.GetById(id);
            if (day != null)
            {
                _unitOfWork.DayRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
