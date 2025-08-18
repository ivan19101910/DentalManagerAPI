using DentalManager.Application.Contracts.Salaries;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("salary-payments")]
public sealed class SalaryPaymentController : ControllerBase
{
    private readonly ISalaryPaymentService _salaryPaymentService;

    public SalaryPaymentController(ISalaryPaymentService salaryPaymentService)
    {
        _salaryPaymentService = salaryPaymentService;
    }

    [HttpGet("get-by-id/{paymentId}")]
    public ActionResult<SalaryPaymentDto> GetById(int paymentId)
    {
        return Ok(_salaryPaymentService.GetById(paymentId));
    }
    
    [HttpGet("get-all")]
    public ActionResult<List<SalaryPaymentDto>> GetAll()
    {
        return Ok(_salaryPaymentService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(CreateSalaryPaymentDto payment, CancellationToken cancellationToken)
    {
        return Ok(_salaryPaymentService.Create(payment, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<CreateSalaryPaymentDto> Update(CreateSalaryPaymentDto salaryPaymentDTO, CancellationToken cancellationToken)
    {
        return Ok(_salaryPaymentService.Update(salaryPaymentDTO, cancellationToken));
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _salaryPaymentService.Delete(id);
        return Ok(id);
    }
}

