namespace DentalManagerAPI.Models
{
    public class AppointmentStatus : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
