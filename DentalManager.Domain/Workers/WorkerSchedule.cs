using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Schedules;

namespace DentalManager.Domain.Workers;

public sealed class WorkerSchedule : IEntity<int>
{
    public int Id { get; init; }

    public int WorkerId { get; init; }

    public int ScheduleId { get; init; }

    public Schedule? Schedule { get; init; }

    public Worker? Worker { get; init; }
}
