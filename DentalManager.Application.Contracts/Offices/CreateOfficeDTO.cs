namespace DentalManager.Application.Contracts.Offices;

public sealed class CreateOfficeDTO
{
    public int Id { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
}
