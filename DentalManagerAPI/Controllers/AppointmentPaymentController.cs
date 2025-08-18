using DentalManager.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("appointment-payments")]
public sealed class AppointmentPaymentController : ControllerBase
{
    private readonly IAppointmentPaymentService _appointmentPaymentService;

    public AppointmentPaymentController(IAppointmentPaymentService appointmentPaymentService)
    {
        _appointmentPaymentService = appointmentPaymentService;
    }

    [HttpGet("get-by-id/{paymentId}")]
    public ActionResult<AppointmentPaymentDto> GetById(int paymentId)
    {
        return Ok(_appointmentPaymentService.GetById(paymentId));
    }

    [HttpGet("get-all")]
    public ActionResult<List<AppointmentPaymentDto>> GetAll()
    {
        return Ok(_appointmentPaymentService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(AppointmentPaymentDto patient, CancellationToken cancellationToken)
    {
        return Ok(_appointmentPaymentService.Create(patient, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<AppointmentPaymentDto> Update(AppointmentPaymentDto appointmentPaymentDTO, CancellationToken cancellationToken)
    {
        return Ok(_appointmentPaymentService.Update(appointmentPaymentDTO, cancellationToken));
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _appointmentPaymentService.Delete(id);
        return Ok(id);
    }
}

