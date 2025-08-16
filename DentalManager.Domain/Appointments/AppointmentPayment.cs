using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Appointments;

public class AppointmentPayment : IEntity<int>
{
    public int Id { get; set; }

    public int TransactionNumber { get; set; }

    public int AppointmentId { get; set; }

    public decimal Total { get; set; }
    public virtual Appointment Appointment { get; set; }
}
