namespace DentalManagerAPI.Models
{
    public class TimeSegment : IEntity<int>
    {
        public int Id { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
