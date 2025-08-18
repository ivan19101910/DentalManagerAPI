namespace DentalManager.Application.Contracts.Positions;

public sealed class PositionDto
{
    public int Id { get; set; }
    public decimal AppointmentPercentage { get; set; }
    public decimal BaseRate { get; set; }
    public string PositionName { get; set; }
}
