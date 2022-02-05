namespace DentalManagerAPI.DTOs
{
    public class TimeSegmentDTO
    {
        public int Id { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
