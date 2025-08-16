using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Cities;

public class City : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
