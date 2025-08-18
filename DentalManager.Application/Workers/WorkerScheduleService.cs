using DentalManager.Application.Contracts.Workers;
using DentalManager.Domain.Workers;
using AutoMapper;

namespace DentalManager.Application.Workers;

public sealed class WorkerScheduleService : IWorkerScheduleService
{
    private readonly IWorkerScheduleRepository _workerScheduleRepository;

    private readonly IMapper _mapper;

    public WorkerScheduleService(IWorkerScheduleRepository workerScheduleRepository, IMapper mapper)
    {
        _workerScheduleRepository = workerScheduleRepository;
        _mapper = mapper;
    }

    public WorkerScheduleDto GetById(int id)
    {
        var schedule = _workerScheduleRepository.GetById(id);

        return _mapper.Map<WorkerScheduleDto>(schedule);
    }

    public List<WorkerScheduleDto> GetAll()
    {
        var schedules = _workerScheduleRepository.GetAll();

        return _mapper.Map<List<WorkerSchedule>, List<WorkerScheduleDto>>(schedules.ToList());
    }

    public int Create(WorkerScheduleDto schedule, CancellationToken cancellationToken)
    {
        var mappedSchedule = _mapper.Map<WorkerScheduleDto, WorkerSchedule>(schedule);
        var newSchedule = _workerScheduleRepository.Add(mappedSchedule, cancellationToken);

        return newSchedule.Id;
    }

    public WorkerScheduleDto Update(WorkerScheduleDto schedule, CancellationToken cancellationToken)
    {
        var updateSchedule = _mapper.Map<WorkerSchedule>(schedule);
        var updatedSchedule = _workerScheduleRepository.Update(updateSchedule, cancellationToken);
        var updatedScheduleDTO = _mapper.Map<WorkerScheduleDto>(updatedSchedule);

        return updatedScheduleDTO;
    }

    public void Delete(int id)
    {
        var schedule = _workerScheduleRepository.GetById(id);

        if (schedule != null)
        {
            _workerScheduleRepository.Delete(id);
        }
    }

    public void DeleteAllByWorkerId(int id)
    {
        var workerSchedules = _workerScheduleRepository.GetByWorkerId(id);

        if (workerSchedules != null)
        {
            foreach (WorkerSchedule workerSchedule in workerSchedules)
            {
                _workerScheduleRepository.Delete(workerSchedule.Id);
            }
        }
    }

    public List<WorkerScheduleDto> UpdateMany(List<WorkerScheduleDto> workerSchedules, int workerId, CancellationToken cancellationToken)
    {
        var comparer = new WorkerScheduleEqualityComparer();
        var schedules = _workerScheduleRepository.GetByWorkerId(workerId);
        var updateWorkerSchedules = _mapper.Map<List<WorkerSchedule>>(workerSchedules);
        var difference = updateWorkerSchedules.Except(schedules, comparer);

        difference = schedules.Except(updateWorkerSchedules, comparer);

        if (difference.Any())
        {
            foreach (var workerSchedule in difference)
            {
                _workerScheduleRepository.Delete(workerSchedule.Id);
            }
        }

        return null;
    }

    class WorkerScheduleEqualityComparer : IEqualityComparer<WorkerSchedule>
    {
        public bool Equals(WorkerSchedule x, WorkerSchedule y)
        {
            return x.Id == y.Id &&
                x.ScheduleId == y.ScheduleId &&
                x.WorkerId == y.WorkerId;
        }

        public int GetHashCode(WorkerSchedule obj)
        {
            unchecked
            {
                if (obj == null)
                    return 0;
                int hashCode = obj.Id.GetHashCode();
                hashCode = hashCode * 397 ^ obj.Id.GetHashCode();
                return hashCode;
            }
        }
    }
}
