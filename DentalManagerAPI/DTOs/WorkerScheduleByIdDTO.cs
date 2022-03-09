namespace DentalManagerAPI.DTOs
{
    public class WorkerScheduleByIdDTO
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ScheduleId { get; set; }
        public string Day { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
