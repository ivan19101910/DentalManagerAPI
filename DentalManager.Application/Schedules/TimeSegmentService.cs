using AutoMapper;
using DentalManager.Application.Contracts.Schedules;
using DentalManager.Domain.Schedules;

namespace DentalManager.Application.Schedules;

public sealed class TimeSegmentService : ITimeSegmentService
{
    private readonly ITimeSegmentRepository _timeSegmentRepository;

    private readonly IMapper _mapper;

    public TimeSegmentService(ITimeSegmentRepository timeSegmentRepository, IMapper mapper)
    {
        _timeSegmentRepository = timeSegmentRepository;
        _mapper = mapper;
    }

    public TimeSegmentDTO GetById(int id)
    {
        var segment = _timeSegmentRepository.GetById(id);

        return _mapper.Map<TimeSegmentDTO>(segment);
    }

    public List<TimeSegmentDTO> GetAll()
    {
        var segment = _timeSegmentRepository.GetAll();

        return _mapper.Map<List<TimeSegment>, List<TimeSegmentDTO>>(segment.ToList());
    }

    public int Create(TimeSegmentDTO segment, CancellationToken cancellationToken)
    {
        var mappedSegment = _mapper.Map<TimeSegmentDTO, TimeSegment>(segment);
        var newSegment = _timeSegmentRepository.Add(mappedSegment, cancellationToken);

        return newSegment.Id;
    }

    public TimeSegmentDTO Update(TimeSegmentDTO segment, CancellationToken cancellationToken)
    {
        var updateSegment = _mapper.Map<TimeSegment>(segment);
        var updatedSegment = _timeSegmentRepository.Update(updateSegment, cancellationToken);

        return _mapper.Map<TimeSegmentDTO>(updatedSegment);
    }

    public void Delete(int id)
    {
        var segment = _timeSegmentRepository.GetById(id);

        if (segment != null)
        {
            _timeSegmentRepository.Delete(id);
        }
    }
}
