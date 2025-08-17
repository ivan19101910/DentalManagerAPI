using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentPaymentController : ControllerBase
{
    private readonly IAppointmentPaymentService _appointmentPaymentService;

    public AppointmentPaymentController(IAppointmentPaymentService appointmentPaymentService)
    {
        _appointmentPaymentService = appointmentPaymentService;
    }

    [HttpGet]
    [Route("getById/{paymentId}")]
    public ActionResult<AppointmentPaymentDTO> GetById(int paymentId)
    {
        var result = _appointmentPaymentService.GetById(paymentId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<AppointmentPaymentDTO>> GetAll()
    {
        var result = _appointmentPaymentService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(AppointmentPaymentDTO patient, CancellationToken cancellationToken)
    {
        try
        {
            var result = _appointmentPaymentService.Create(patient, cancellationToken);
            if (result != null)
                return result;
            else
                return BadRequest();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    [Route("update")]
    public ActionResult<AppointmentPaymentDTO> Update(AppointmentPaymentDTO appointmentPaymentDTO, CancellationToken cancellationToken)
    {
        try
        {
            var result = _appointmentPaymentService.Update(appointmentPaymentDTO, cancellationToken);
            return result;
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        try
        {
            _appointmentPaymentService.Delete(id);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        return id;
    }
}


