using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Days;

public class Day : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
