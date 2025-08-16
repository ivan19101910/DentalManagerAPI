namespace DentalManager.Application.Contracts.Workers;

public sealed class ShowWorkerDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PositionName { get; set; }
    public string OfficeAddress { get; set; }
    public string City { get; set; }
}
