namespace DentalManagerAPI.DTOs
{
    public class AppointmentPaymentDTO
    {
        public int Id { get; set; }

        public int TransactionNumber { get; set; }

        public int AppointmentId { get; set; }

        public decimal Total { get; set; }
    }
}
