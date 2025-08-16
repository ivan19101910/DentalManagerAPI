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

    public ScheduleDTO GetById(int id)
    {
        var schedule = _scheduleRepository.GetById(id);
        return _mapper.Map<ScheduleDTO>(schedule);
    }

    public List<ShowScheduleDTO> GetAll()
    {
        var schedules = _scheduleRepository.GetAll();
        return _mapper.Map<List<Schedule>, List<ShowScheduleDTO>>(schedules.ToList());
    }

    public int Create(ScheduleDTO schedule)
    {
        var mappedSchedule = _mapper.Map<ScheduleDTO, Schedule>(schedule);
        var newSchedule = _scheduleRepository.Add(mappedSchedule);
        return newSchedule.Id;
    }

    public ScheduleDTO Update(ScheduleDTO schedule)
    {
        var updateSchedule = _mapper.Map<Schedule>(schedule);
        var updatedSchedule = _scheduleRepository.Edit(updateSchedule);
        var updatedScheduleDTO = _mapper.Map<ScheduleDTO>(updatedSchedule);
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
