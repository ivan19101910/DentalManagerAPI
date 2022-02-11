namespace DentalManagerAPI.DTOs
{
    public class UpdateWorkerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Address { get; set; }
        public int PositionId { get; set; }
        public int? OfficeId { get; set; }
    }
}
