using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("appointments")]
public sealed class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    private readonly IAppointmentServiceService _appointmentServiceService;

    public AppointmentController(IAppointmentService appointmentService, IAppointmentServiceService appointmentServiceService)
    {
        _appointmentService = appointmentService;
        _appointmentServiceService = appointmentServiceService;
    }

    [HttpGet("get-all")]
    public ActionResult<List<ShortAppointmentDto>> GetAll()
    {
        return Ok(_appointmentService.GetAll());
    }

    [HttpGet("get-by-id/{appointmentId}")]
    public ActionResult<FullAppointmentDto> GetById(int appointmentId)
    {
        return Ok(_appointmentService.GetById(appointmentId));
    }

    [HttpGet("get-by-phone-number/{phoneNumber}")]
    public ActionResult<List<FullAppointmentDto>> GetByPhoneNumber(string phoneNumber)
    {
        return Ok(_appointmentService.GetByPhoneNumber(phoneNumber));
    }

    [HttpGet("get-by-worker-id/{workerId}")]
    public ActionResult<List<FullAppointmentDto>> GetByWorkerId(int workerId)
    {
        return Ok(_appointmentService.GetByWorkerId(workerId));
    }

    [HttpGet("get-by-patient-id/{patientId}")]
    public ActionResult<List<FullAppointmentDto>> GetByPatientId(int patientId)
    {
        return Ok(_appointmentService.GetByPatientId(patientId));
    }

    [HttpPost]
    public ActionResult<int> Create(CreateAppointmentDto appointment, CancellationToken cancellationToken)
    {
        return Ok(_appointmentService.Create(appointment, cancellationToken));
    }

    [HttpPut]
    public ActionResult<EditAppointmentDto> Update(EditAppointmentDto appointmentDTO, CancellationToken cancellationToken)
    {
        var result = _appointmentService.Update(appointmentDTO, cancellationToken);

        if (result.AppointmentServices == null || result.AppointmentServices.Count == 0)
        {
            _appointmentServiceService.DeleteAllByAppointmentId(result.Id);
        }
        else
        {
            _appointmentServiceService.UpdateMany(appointmentDTO.AppointmentServices, result.Id, cancellationToken);
        }

        return Ok(result);
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _appointmentService.Delete(id);
        return Ok(id);
    }
}
