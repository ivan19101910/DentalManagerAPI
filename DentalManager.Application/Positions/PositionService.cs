using DentalManager.Application.Contracts.Positions;
using DentalManager.Domain.Positions;
using AutoMapper;

namespace DentalManager.Application.Positions;

public sealed class PositionService : IPositionService
{
    private readonly IPositionRepository _positionRepository;

    private readonly IMapper _mapper;

    public PositionService(IPositionRepository positionRepository, IMapper mapper)
    {
        _positionRepository = positionRepository;
        _mapper = mapper;
    }

    public PositionDTO GetById(int id)
    {
        var position = _positionRepository.GetById(id);

        return _mapper.Map<PositionDTO>(position);
    }

    public List<PositionDTO> GetAll()
    {
        var positions = _positionRepository.GetAll();

        return _mapper.Map<List<Position>, List<PositionDTO>>(positions.ToList());
    }

    public int Create(PositionDTO office, CancellationToken cancellationToken)
    {
        var mappedPosition = _mapper.Map<PositionDTO, Position>(office);
        var newPosition = _positionRepository.Add(mappedPosition, cancellationToken);

        return newPosition.Id;
    }

    public PositionDTO Update(PositionDTO position, CancellationToken cancellationToken)
    {
        var updatePosition = _mapper.Map<Position>(position);
        var updatedPosition = _positionRepository.Update(updatePosition, cancellationToken);
        var updatedPositionDTO = _mapper.Map<PositionDTO>(updatedPosition);

        return updatedPositionDTO;
    }

    public void Delete(int id)
    {
        var position = _positionRepository.GetById(id);

        if (position != null)
        {
            _positionRepository.Delete(id);
        }
    }
}
