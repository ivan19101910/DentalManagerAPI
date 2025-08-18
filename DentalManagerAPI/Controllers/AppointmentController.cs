using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public sealed class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    private readonly IAppointmentServiceService _appointmentServiceService;

    public AppointmentController(IAppointmentService appointmentService, IAppointmentServiceService appointmentServiceService)
    {
        _appointmentService = appointmentService;
        _appointmentServiceService = appointmentServiceService;
    }

    [HttpGet("getAll")]
    public ActionResult<List<ShortAppointmentDTO>> GetAll()
    {
        return Ok(_appointmentService.GetAll());
    }

    [HttpGet("getById/{appointmentId}")]
    public ActionResult<FullAppointmentDTO> GetById(int appointmentId)
    {
        return Ok(_appointmentService.GetById(appointmentId));
    }

    [HttpGet("getByPhoneNumber/{phoneNumber}")]
    public ActionResult<List<FullAppointmentDTO>> GetByPhoneNumber(string phoneNumber)
    {
        return Ok(_appointmentService.GetByPhoneNumber(phoneNumber));
    }

    [HttpGet("getByWorkerId/{workerId}")]
    public ActionResult<List<FullAppointmentDTO>> GetByWorkerId(int workerId)
    {
        return Ok(_appointmentService.GetByWorkerId(workerId));
    }

    [HttpGet("getByPatientId/{patientId}")]
    public ActionResult<List<FullAppointmentDTO>> GetByPatientId(int patientId)
    {
        return Ok(_appointmentService.GetByPatientId(patientId));
    }

    [HttpPost("create")]
    public ActionResult<int> Create(CreateAppointmentDTO appointment, CancellationToken cancellationToken)
    {
        return Ok(_appointmentService.Create(appointment, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<EditAppointmentDTO> Update(EditAppointmentDTO appointmentDTO, CancellationToken cancellationToken)
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

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _appointmentService.Delete(id);
        return Ok(id);
    }
}
