using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    private readonly IAppointmentServiceService _appointmentServiceService;
    
    public AppointmentController(IAppointmentService appointmentService, IAppointmentServiceService appointmentServiceService)
    {
        _appointmentService = appointmentService;
        _appointmentServiceService = appointmentServiceService;
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<ShortAppointmentDTO>> GetAll()
    {
        var result = _appointmentService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getById/{appointmentId}")]
    public ActionResult<FullAppointmentDTO> GetById(int appointmentId)
    {
        var result = _appointmentService.GetById(appointmentId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getByPhoneNumber/{phoneNumber}")]
    public ActionResult<List<FullAppointmentDTO>> GetByPhoneNumber(string phoneNumber)
    {
        var result = _appointmentService.GetByPhoneNumber(phoneNumber);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getByWorkerId/{workerId}")]
    public ActionResult<List<FullAppointmentDTO>> GetByWorkerId(int workerId)
    {
        var result = _appointmentService.GetByWorkerId(workerId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getByPatientId/{patientId}")]
    public ActionResult<List<FullAppointmentDTO>> GetByPatientId(int patientId)
    {
        var result = _appointmentService.GetByPatientId(patientId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(CreateAppointmentDTO appointment, CancellationToken cancellationToken)
    {
        var result = _appointmentService.Create(appointment, cancellationToken);
        if (result != null)
        {
            return result;
        }
        else
            return BadRequest();
    }

    [HttpPut]
    [Route("update")]
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
        return result;
    }
    
    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _appointmentService.Delete(id);
        return id;
    }
}
