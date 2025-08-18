namespace DentalManager.Application.Contracts.Offices;

public sealed class CreateOfficeDto
{
    public int Id { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
}
