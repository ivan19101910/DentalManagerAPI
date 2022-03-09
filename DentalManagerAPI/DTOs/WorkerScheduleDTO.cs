using DentalManagerAPI.Models;

namespace DentalManagerAPI.DTOs
{
    public class WorkerScheduleDTO
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int ScheduleId { get; set; }
    }
}
