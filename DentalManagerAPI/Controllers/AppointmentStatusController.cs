using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AppointmentStatusController : ControllerBase
{
    private readonly IAppointmentStatusService _appointmentStatusService;

    public AppointmentStatusController(IAppointmentStatusService appointmentStatusService)
    {
        _appointmentStatusService = appointmentStatusService;
    }

    [HttpGet("getById/{statusId}")]
    public ActionResult<AppointmentStatusDTO> GetById(int statusId)
    {
        return Ok(_appointmentStatusService.GetById(statusId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<AppointmentStatusDTO>> GetAll()
    {
        return Ok(_appointmentStatusService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(AppointmentStatusDTO patient, CancellationToken cancellationToken)
    {
        return Ok(_appointmentStatusService.Create(patient, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<AppointmentStatusDTO> Update(AppointmentStatusDTO appointmentStatusDTO, CancellationToken cancellationToken)
    {
        return Ok(_appointmentStatusService.Update(appointmentStatusDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _appointmentStatusService.Delete(id);
        return Ok(id);
    }
}

