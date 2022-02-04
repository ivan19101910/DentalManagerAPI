namespace DentalManagerAPI.Models
{
    public class AppointmentPayment : IEntity<int>
    {
        public int Id { get; set; }

        public int TransactionNumber { get; set; }

        public int AppointmentId { get; set; }

        public decimal Total { get; set; }
    }
}
