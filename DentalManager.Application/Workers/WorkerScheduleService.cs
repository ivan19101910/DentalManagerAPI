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

    public WorkerScheduleDTO GetById(int id)
    {
        var schedule = _workerScheduleRepository.GetById(id);

        return _mapper.Map<WorkerScheduleDTO>(schedule);
    }

    public List<WorkerScheduleDTO> GetAll()
    {
        var schedules = _workerScheduleRepository.GetAll();

        return _mapper.Map<List<WorkerSchedule>, List<WorkerScheduleDTO>>(schedules.ToList());
    }

    public int Create(WorkerScheduleDTO schedule, CancellationToken cancellationToken)
    {
        var mappedSchedule = _mapper.Map<WorkerScheduleDTO, WorkerSchedule>(schedule);
        var newSchedule = _workerScheduleRepository.Add(mappedSchedule, cancellationToken);

        return newSchedule.Id;
    }

    public WorkerScheduleDTO Update(WorkerScheduleDTO schedule, CancellationToken cancellationToken)
    {
        var updateSchedule = _mapper.Map<WorkerSchedule>(schedule);
        var updatedSchedule = _workerScheduleRepository.Update(updateSchedule, cancellationToken);
        var updatedScheduleDTO = _mapper.Map<WorkerScheduleDTO>(updatedSchedule);

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

    public List<int> CreateMany(List<WorkerScheduleDTO> schedulesList, int workerId, CancellationToken cancellationToken)
    {
        List<int> createdIds = new List<int>();

        foreach (var schedule in schedulesList)
        {
            var mappedSchedule = _mapper.Map<WorkerScheduleDTO, WorkerSchedule>(schedule);
            mappedSchedule.WorkerId = workerId;
            var newSchedule = _workerScheduleRepository.Add(mappedSchedule, cancellationToken);
            createdIds.Add(newSchedule.Id);
        }

        return createdIds;
    }

    public List<WorkerScheduleDTO> UpdateMany(List<WorkerScheduleDTO> workerSchedules, int workerId, CancellationToken cancellationToken)
    {
        var comparer = new WorkerScheduleEqualityComparer();
        var schedules = _workerScheduleRepository.GetByWorkerId(workerId);
        var updateWorkerSchedules = _mapper.Map<List<WorkerSchedule>>(workerSchedules);
        var difference = updateWorkerSchedules.Except(schedules, comparer);

        if (difference.Any())
        {
            CreateMany(_mapper.Map<List<WorkerScheduleDTO>>(difference), workerId, cancellationToken);
        }

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
