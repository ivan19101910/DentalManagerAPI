namespace DentalManager.Application.Contracts.Schedules;

public sealed class ScheduleDTO
{
    public int Id { get; set; }
    public int DayId { get; set; }
    public int TimeSegmentId { get; set; }
}
