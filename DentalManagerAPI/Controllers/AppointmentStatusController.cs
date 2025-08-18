using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentStatusController : ControllerBase
{
    private readonly IAppointmentStatusService _appointmentStatusService;
    public AppointmentStatusController(IAppointmentStatusService appointmentStatusService)
    {
        _appointmentStatusService = appointmentStatusService;
    }

    [HttpGet]
    [Route("getById/{statusId}")]
    public ActionResult<AppointmentStatusDTO> GetById(int statusId)
    {
        var result = _appointmentStatusService.GetById(statusId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<AppointmentStatusDTO>> GetAll()
    {
        var result = _appointmentStatusService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(AppointmentStatusDTO patient, CancellationToken cancellationToken)
    {
        var result = _appointmentStatusService.Create(patient, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }
    [HttpPut]
    [Route("update")]
    public ActionResult<AppointmentStatusDTO> Update(AppointmentStatusDTO appointmentStatusDTO, CancellationToken cancellationToken)
    {
        var result = _appointmentStatusService.Update(appointmentStatusDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _appointmentStatusService.Delete(id);
        return id;
    }
}

