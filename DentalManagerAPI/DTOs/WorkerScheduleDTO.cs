using DentalManagerAPI.Models;

namespace DentalManagerAPI.DTOs
{
    public class WorkerScheduleDTO
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
