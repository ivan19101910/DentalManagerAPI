using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Patients;
using DentalManager.Domain.Workers;

namespace DentalManager.Domain.Appointments;

public sealed class Appointment : IEntity<int>
{
    public int Id { get; init; }

    public DateTime AppointmentDate { get; init; }

    public string? Notes { get; init; }

    public TimeSpan? RealEndTime { get; init; }

    public TimeSpan AppointmentTime { get; init; }

    public int WorkerId { get; init; }

    public int PatientId { get; init; }

    public int StatusId { get; init; }

    public decimal? TotalSum { get; init; }

    public Patient? Patient { get; init; }

    public AppointmentStatus? Status { get; init; }

    public Worker? Worker { get; init; }

    public IList<AppointmentService> AppointmentServices { get; init; } = [];

    public void AddServices(IEnumerable<AppointmentService> services)
    {

    }
}
