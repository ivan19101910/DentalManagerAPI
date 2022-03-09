using DentalManagerAPI.Models;

namespace DentalManagerAPI.DTOs
{
    public class CreateWorkerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Address { get; set; }
        public int PositionId { get; set; }
        public int? OfficeId { get; set; }
        public List<WorkerScheduleDTO>? WorkerSchedules {get;set;}
    }
}
