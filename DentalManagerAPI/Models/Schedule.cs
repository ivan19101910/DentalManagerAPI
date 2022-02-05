namespace DentalManagerAPI.Models
{
    public class Schedule : IEntity<int>
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public int TimeSegmentId { get; set; }
        public virtual Day Day { get; set; }
        public virtual TimeSegment TimeSegment { get; set; }
    }
}
