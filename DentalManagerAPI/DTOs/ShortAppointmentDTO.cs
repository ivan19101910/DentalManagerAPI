namespace DentalManagerAPI.DTOs
{
    public class ShortAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }       
    }
}
