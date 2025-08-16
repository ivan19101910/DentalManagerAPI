namespace DentalManager.Application.Contracts.Offices;

public sealed class OfficeDTO
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public int CityId { get; set; }
}
