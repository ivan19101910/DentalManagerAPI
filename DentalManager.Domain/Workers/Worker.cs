using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Appointments;
using DentalManager.Domain.Offices;
using DentalManager.Domain.Positions;

namespace DentalManager.Domain.Workers;

public sealed class Worker : IEntity<int>
{
    public int Id { get; init; }

    public required string FirstName { get; init; }   

    public required string LastName { get; init; }  

    public string? PhoneNumber { get; init; }   
    
    public string? Email { get; init; }
    
    public string? Password { get; init; }
    
    public required string Address { get; init; }

    public int? PositionId { get; init; }

    public int? OfficeId { get; init; }

    public Office? Office { get; init; }

    public Position? Position { get; init; }

    public List<WorkerSchedule> WorkerSchedules { get; init; } = [];

    public IList<Appointment> Appointments { get; init; } = [];

    public void AddSchedules(List<WorkerSchedule> schedules)
    {
        WorkerSchedules.AddRange(schedules); 
    }
}
