namespace DentalManager.Application.Contracts.Schedules;

public sealed class ScheduleDto
{
    public int Id { get; set; }
    public int DayId { get; set; }
    public int TimeSegmentId { get; set; }
}
