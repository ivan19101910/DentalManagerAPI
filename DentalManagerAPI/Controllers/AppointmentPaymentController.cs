using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AppointmentPaymentController : ControllerBase
{
    private readonly IAppointmentPaymentService _appointmentPaymentService;

    public AppointmentPaymentController(IAppointmentPaymentService appointmentPaymentService)
    {
        _appointmentPaymentService = appointmentPaymentService;
    }

    [HttpGet("getById/{paymentId}")]
    public ActionResult<AppointmentPaymentDTO> GetById(int paymentId)
    {
        return Ok(_appointmentPaymentService.GetById(paymentId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<AppointmentPaymentDTO>> GetAll()
    {
        return Ok(_appointmentPaymentService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(AppointmentPaymentDTO patient, CancellationToken cancellationToken)
    {
        return Ok(_appointmentPaymentService.Create(patient, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<AppointmentPaymentDTO> Update(AppointmentPaymentDTO appointmentPaymentDTO, CancellationToken cancellationToken)
    {
        return Ok(_appointmentPaymentService.Update(appointmentPaymentDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _appointmentPaymentService.Delete(id);
        return Ok(id);
    }
}

