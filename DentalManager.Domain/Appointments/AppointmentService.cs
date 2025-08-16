using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Services;

namespace DentalManager.Domain.Appointments;

public sealed class AppointmentService : IEntity<int>
{
    public int Id { get; init; }

    public int ServiceId { get; init; }

    public int AppointmentId { get; init; }

    public int Amount { get; init; }
    
    public Service? Service { get; set; }
}
