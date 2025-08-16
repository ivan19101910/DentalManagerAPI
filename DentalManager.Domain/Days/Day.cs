using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Days;

public sealed class Day : IEntity<int>
{
    public int Id { get; init; }
    
    public required string Name { get; init; }
}
