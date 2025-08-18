namespace DentalManager.Application.Contracts.Appointments;

public sealed class AppointmentDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; }
    public TimeSpan? RealEndTime { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public int WorkerId { get; set; }
    public int PatientId { get; set; }
    public int StatusId { get; set; }
    public decimal? TotalSum { get; set; }

    //TODO: Review and add dto-s instead of using models
    /*public virtual Patient Patient { get; set; }
    public virtual AppointmentStatus Status { get; set; }
    public virtual Worker Worker { get; set; }
    public virtual List<AppointmentService> AppointmentServices { get; set; }*/
}
