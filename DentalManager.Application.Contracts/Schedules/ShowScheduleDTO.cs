namespace DentalManager.Application.Contracts.Schedules;

public sealed class ShowScheduleDto
{
    public int Id { get; set; }
    public string Day { get; set; }
    public int DayId { get; set; }
    public int TimeSegmentId { get; set; }
    public TimeSpan TimeStart { get; set; }
    public TimeSpan TimeEnd { get; set; }
}
