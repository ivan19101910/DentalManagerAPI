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

    [HttpGet]
    [Route("getById/{paymentId}")]
    public ActionResult<SalaryPaymentDTO> GetById(int paymentId)
    {
        var result = _salaryPaymentService.GetById(paymentId);
        if (result != null)
            return result;
        else
            return NotFound();
    }
    
    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<SalaryPaymentDTO>> GetAll()
    {
        var result = _salaryPaymentService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(CreateSalaryPaymentDTO payment, CancellationToken cancellationToken)
    {
        var result = _salaryPaymentService.Create(payment, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }

    [HttpPut]
    [Route("update")]
    public ActionResult<CreateSalaryPaymentDTO> Update(CreateSalaryPaymentDTO salaryPaymentDTO, CancellationToken cancellationToken)
    {
        var result = _salaryPaymentService.Update(salaryPaymentDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _salaryPaymentService.Delete(id);
        return id;
    }
}

