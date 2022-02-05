using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class TimeSegmentService : ITimeSegmentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TimeSegmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TimeSegmentDTO GetById(int id)
        {
            var segment = _unitOfWork.TimeSegmentRepository.GetById(id);

            return _mapper.Map<TimeSegmentDTO>(segment);
        }

        public List<TimeSegmentDTO> GetAll()
        {
            var segment = _unitOfWork.TimeSegmentRepository.GetAll();
            return _mapper.Map<List<TimeSegment>, List<TimeSegmentDTO>>(segment.ToList());
        }

        public int Create(TimeSegmentDTO segment)
        {
            var mappedSegment = _mapper.Map<TimeSegmentDTO, TimeSegment>(segment);

            var newSegment = _unitOfWork.TimeSegmentRepository.Add(mappedSegment);
            _unitOfWork.Save();

            return newSegment.Id;
        }

        public TimeSegmentDTO Update(TimeSegmentDTO segment)
        {
            var updateSegment = _mapper.Map<TimeSegment>(segment);
            var updatedSegment = _unitOfWork.TimeSegmentRepository.Edit(updateSegment);

            _unitOfWork.Save();

            return _mapper.Map<TimeSegmentDTO>(updatedSegment);
        }

        public void Delete(int id)
        {
            var segment = _unitOfWork.TimeSegmentRepository.GetById(id);
            if (segment != null)
            {
                _unitOfWork.TimeSegmentRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
