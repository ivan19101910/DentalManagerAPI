using DentalManager.Domain.Abstractions;
using DentalManager.Domain.Cities;

namespace DentalManager.Domain.Offices;

public sealed class Office : IEntity<int>
{
    public int Id { get; init; }

    public required string Address { get; init; }

    public int CityId { get; init; }

    public City? City { get; init; }
}
