using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Appointments;

public sealed class AppointmentStatus : IEntity<int>
{
    public int Id { get; init; }

    public required string Name { get; init; }
}
