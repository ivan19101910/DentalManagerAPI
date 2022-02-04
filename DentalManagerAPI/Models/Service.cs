namespace DentalManagerAPI.Models
{
    public class Service : IEntity<int>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; }
    }
}
