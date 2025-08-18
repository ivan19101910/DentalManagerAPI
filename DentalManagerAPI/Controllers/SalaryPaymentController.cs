using DentalManager.Application.Contracts.Salaries;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class SalaryPaymentController : ControllerBase
{
    private readonly ISalaryPaymentService _salaryPaymentService;

    public SalaryPaymentController(ISalaryPaymentService salaryPaymentService)
    {
        _salaryPaymentService = salaryPaymentService;
    }

    [HttpGet("getById/{paymentId}")]
    public ActionResult<SalaryPaymentDTO> GetById(int paymentId)
    {
        return Ok(_salaryPaymentService.GetById(paymentId));
    }
    
    [HttpGet("getAll")]
    public ActionResult<List<SalaryPaymentDTO>> GetAll()
    {
        return Ok(_salaryPaymentService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(CreateSalaryPaymentDTO payment, CancellationToken cancellationToken)
    {
        return Ok(_salaryPaymentService.Create(payment, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<CreateSalaryPaymentDTO> Update(CreateSalaryPaymentDTO salaryPaymentDTO, CancellationToken cancellationToken)
    {
        return Ok(_salaryPaymentService.Update(salaryPaymentDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _salaryPaymentService.Delete(id);
        return Ok(id);
    }
}

