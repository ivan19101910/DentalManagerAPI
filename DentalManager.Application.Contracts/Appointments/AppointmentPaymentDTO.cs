namespace DentalManager.Application.Contracts.Appointments;

public class AppointmentPaymentDto
{
    public int Id { get; set; }

    public int TransactionNumber { get; set; }

    public int AppointmentId { get; set; }

    public decimal Total { get; set; }
}
