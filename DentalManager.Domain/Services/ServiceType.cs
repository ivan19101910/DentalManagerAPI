using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Services;

public class ServiceType : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
