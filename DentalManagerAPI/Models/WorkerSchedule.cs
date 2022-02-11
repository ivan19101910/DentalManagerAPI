namespace DentalManagerAPI.Models
{
    public class WorkerSchedule : IEntity<int>
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
