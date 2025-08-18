namespace DentalManager.Application.Contracts.Schedules;

public sealed class TimeSegmentDto
{
    public int Id { get; set; }
    public string TimeStart { get; set; }
    public string TimeEnd { get; set; }
}
