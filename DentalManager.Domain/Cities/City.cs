using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Cities;

public sealed class City : IEntity<int>
{
    public int Id { get; init; }

    public required string Name { get; init; }
}
