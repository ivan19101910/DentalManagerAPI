using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Patients;

public sealed class Patient : IEntity<int>
{
    public int Id { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Address { get; init; }

    public DateTime DateOfBirth { get; init; }   

    public required string PhoneNumber { get; init; }
}
