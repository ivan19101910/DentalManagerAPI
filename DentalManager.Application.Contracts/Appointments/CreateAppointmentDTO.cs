namespace DentalManager.Application.Contracts.Appointments;

public sealed class CreateAppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
    public string? RealEndTime { get; set; }
    public string AppointmentTime { get; set; }
    public int WorkerId { get; set; }
    public int PatientId { get; set; }
    public int StatusId { get; set; }
    public decimal? TotalSum { get; set; }
    public List<AppointmentServiceDto>? AppointmentServices { get; set; }
}
