namespace DentalManager.Application.Contracts.Services;

public sealed class ServiceDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ServiceTypeId { get; set; }
    public string ServiceTypeName { get; set; }
}
