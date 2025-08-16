using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Days;

namespace DentalManager.Domain.Schedules;

public sealed class Schedule : IEntity<int>
{
    public int Id { get; init; }
    public int DayId { get; init; }
    public int TimeSegmentId { get; init; }
    public Day? Day { get; init; }
    public TimeSegment? TimeSegment { get; init; }
}
