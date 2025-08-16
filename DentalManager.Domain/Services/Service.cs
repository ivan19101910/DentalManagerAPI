using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Services;

public sealed class Service : IEntity<int>
{
    public int Id { get; init; }

    public decimal Price { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public int ServiceTypeId { get; init; }

    public ServiceType? ServiceType { get; init; }
}
