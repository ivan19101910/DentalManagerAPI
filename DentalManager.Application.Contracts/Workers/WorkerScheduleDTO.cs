namespace DentalManager.Application.Contracts.Workers;

public sealed class WorkerScheduleDTO
{
    public int Id { get; set; }
    public int WorkerId { get; set; }
    public int ScheduleId { get; set; }
}
