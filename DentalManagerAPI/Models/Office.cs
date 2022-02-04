namespace DentalManagerAPI.Models
{
    public class Office : IEntity<int>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
