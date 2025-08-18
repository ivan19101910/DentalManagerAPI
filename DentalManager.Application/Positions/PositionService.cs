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

    public PositionDto GetById(int id)
    {
        var position = _positionRepository.GetById(id);

        return _mapper.Map<PositionDto>(position);
    }

    public List<PositionDto> GetAll()
    {
        var positions = _positionRepository.GetAll();

        return _mapper.Map<List<Position>, List<PositionDto>>(positions.ToList());
    }

    public int Create(PositionDto office, CancellationToken cancellationToken)
    {
        var mappedPosition = _mapper.Map<PositionDto, Position>(office);
        var newPosition = _positionRepository.Add(mappedPosition, cancellationToken);

        return newPosition.Id;
    }

    public PositionDto Update(PositionDto position, CancellationToken cancellationToken)
    {
        var updatePosition = _mapper.Map<Position>(position);
        var updatedPosition = _positionRepository.Update(updatePosition, cancellationToken);
        var updatedPositionDTO = _mapper.Map<PositionDto>(updatedPosition);

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
