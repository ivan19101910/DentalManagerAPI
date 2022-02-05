using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class PositionService : IPositionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PositionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PositionDTO GetById(int id)
        {
            var position = _unitOfWork.PositionRepository.GetById(id);

            return _mapper.Map<PositionDTO>(position);
        }

        public List<PositionDTO> GetAll()
        {
            var positions = _unitOfWork.PositionRepository.GetAll();
            return _mapper.Map<List<Position>, List<PositionDTO>>(positions.ToList());
        }

        public int Create(PositionDTO office)
        {
            var mappedPosition = _mapper.Map<PositionDTO, Position>(office);

            var newPosition = _unitOfWork.PositionRepository.Add(mappedPosition);
            _unitOfWork.Save();

            return newPosition.Id;
        }

        public PositionDTO Update(PositionDTO position)
        {
            var updatePosition = _mapper.Map<Position>(position);
            var updatedPosition = _unitOfWork.PositionRepository.Edit(updatePosition);

            _unitOfWork.Save();

            var updatedPositionDTO = _mapper.Map<PositionDTO>(updatedPosition);

            return updatedPositionDTO;
        }

        public void Delete(int id)
        {
            var position = _unitOfWork.PositionRepository.GetById(id);
            if (position != null)
            {
                _unitOfWork.PositionRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
