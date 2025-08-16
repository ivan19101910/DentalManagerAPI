using DentalManager.Domain.Abstractions;

namespace DentalManager.Domain.Positions;

public class Position : IEntity<int>
{
    public int Id { get; set; }
    public decimal AppointmentPercentage { get; set; }
    public decimal BaseRate { get; set; }
    public string PositionName { get; set; }

}
