using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Positions;

public sealed class Position : IEntity<int>
{
    public int Id { get; init; }

    public decimal AppointmentPercentage { get; init; }

    public decimal BaseRate { get; init; }

    public required string PositionName { get; init; }
}
