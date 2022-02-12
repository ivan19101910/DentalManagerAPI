namespace DentalManagerAPI.DTOs
{
    public class FullAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }
        public TimeSpan? RealEndTime { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int WorkerId { get; set; }
        public int PatientId { get; set; }
        public int StatusId { get; set; }
        public decimal? TotalSum { get; set; }
        public List<AppointmentServiceDTO>? AppointmentServices { get; set; }
    }
}
