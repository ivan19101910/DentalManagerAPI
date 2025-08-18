using DentalManager.Application.Contracts.Days;
using DentalManager.Domain.Days;
using AutoMapper;

namespace DentalManager.Application.Days;

public sealed class DayService : IDayService
{
    private readonly IDayRepository _dayRepository;

    private readonly IMapper _mapper;

    public DayService(IDayRepository dayRepository, IMapper mapper)
    {
        _dayRepository = dayRepository;
        _mapper = mapper;
    }

    public DayDto GetById(int id)
    {
        var day = _dayRepository.GetById(id);

        return _mapper.Map<DayDto>(day);
    }

    public List<DayDto> GetAll()
    {
        var days = _dayRepository.GetAll();

        return _mapper.Map<List<Day>, List<DayDto>>(days.ToList());
    }

    public int Create(DayDto day, CancellationToken cancellationToken)
    {
        var mappedDay = _mapper.Map<DayDto, Day>(day);
        var newDay = _dayRepository.Add(mappedDay, cancellationToken);

        return newDay.Id;
    }

    public DayDto Update(DayDto day, CancellationToken cancellationToken)
    {
        var updateDay = _mapper.Map<Day>(day);
        var updatedDay = _dayRepository.Update(updateDay, cancellationToken);
        var updatedDayDTO = _mapper.Map<DayDto>(updatedDay);

        return updatedDayDTO;
    }

    public void Delete(int id)
    {
        var day = _dayRepository.GetById(id);

        if (day != null)
        {
            _dayRepository.Delete(id);
        }
    }
}
