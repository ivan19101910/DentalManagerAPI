using AutoMapper;
using DentalManager.Application.Contracts.Schedules;
using DentalManager.Domain.Schedules;

namespace DentalManager.Application.Schedules;

public sealed class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    private readonly IMapper _mapper;

    public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public ScheduleDto GetById(int id)
    {
        var schedule = _scheduleRepository.GetById(id);

        return _mapper.Map<ScheduleDto>(schedule);
    }

    public List<ShowScheduleDto> GetAll()
    {
        var schedules = _scheduleRepository.GetAll();

        return _mapper.Map<List<Schedule>, List<ShowScheduleDto>>(schedules.ToList());
    }

    public int Create(ScheduleDto schedule, CancellationToken cancellationToken)
    {
        var mappedSchedule = _mapper.Map<ScheduleDto, Schedule>(schedule);
        var newSchedule = _scheduleRepository.Add(mappedSchedule, cancellationToken);

        return newSchedule.Id;
    }

    public ScheduleDto Update(ScheduleDto schedule, CancellationToken cancellationToken)
    {
        var updateSchedule = _mapper.Map<Schedule>(schedule);
        var updatedSchedule = _scheduleRepository.Update(updateSchedule, cancellationToken);
        var updatedScheduleDTO = _mapper.Map<ScheduleDto>(updatedSchedule);

        return updatedScheduleDTO;
    }

    public void Delete(int id)
    {
        var schedule = _scheduleRepository.GetById(id);

        if (schedule != null)
        {
            _scheduleRepository.Delete(id);
        }
    }
}
