using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Schedules;

public sealed class TimeSegment : IEntity<int>
{
    public int Id { get; init; }

    public TimeSpan TimeStart { get; init; }

    public TimeSpan TimeEnd { get; init; }
}
