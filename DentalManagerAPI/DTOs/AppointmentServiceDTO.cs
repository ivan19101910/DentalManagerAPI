namespace DentalManagerAPI.DTOs
{
    public class AppointmentServiceDTO
    {
        public int Id { get; set; }
        
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public int AppointmentId { get; set; }
        public int Amount { get; set; }
    }
}
