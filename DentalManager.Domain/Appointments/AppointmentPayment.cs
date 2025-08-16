using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Appointments;

public sealed class AppointmentPayment : IEntity<int>
{
    public int Id { get; init; }

    public int TransactionNumber { get; init; }

    public int AppointmentId { get; init; }

    public decimal Total { get; init; }

    public Appointment? Appointment { get; init; }
}
