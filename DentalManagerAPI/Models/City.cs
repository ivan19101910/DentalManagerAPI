namespace DentalManagerAPI.Models
{
    public class City : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
