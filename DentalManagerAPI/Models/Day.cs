namespace DentalManagerAPI.Models
{
    public class Day : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
