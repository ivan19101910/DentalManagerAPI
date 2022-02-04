namespace DentalManagerAPI.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
    }
}
