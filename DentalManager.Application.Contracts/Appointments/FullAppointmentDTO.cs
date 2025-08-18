using DentalManager.Application.Contracts.Patients;
using DentalManager.Application.Contracts.Workers;

namespace DentalManager.Application.Contracts.Appointments;

public sealed class FullAppointmentDto
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
    public FullWorkerDto Worker { get; set; }
    public PatientDto Patient { get; set; }
    public AppointmentStatusDto Status { get; set; }
    public List<AppointmentServiceDto>? AppointmentServices { get; set; }
}
