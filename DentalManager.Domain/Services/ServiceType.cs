using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Services;

public sealed class ServiceType : IEntity<int>
{
    public int Id { get; init; }

    public required string Name { get; init; }
}
