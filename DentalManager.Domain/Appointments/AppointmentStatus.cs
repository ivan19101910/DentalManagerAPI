using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Appointments;

public class AppointmentStatus : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
