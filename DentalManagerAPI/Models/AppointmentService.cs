namespace DentalManagerAPI.Models
{
    public class AppointmentService : IEntity<int>
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int AppointmentId { get; set; }
        public int Amount { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Service Service { get; set; }
    }
}
