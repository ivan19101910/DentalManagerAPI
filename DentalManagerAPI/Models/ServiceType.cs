namespace DentalManagerAPI.Models
{
    public class ServiceType : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
