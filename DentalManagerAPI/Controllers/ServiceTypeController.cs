using DentalManager.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ServiceTypeController : ControllerBase
{
    private readonly IServiceTypeService _serviceTypeService;

    public ServiceTypeController(IServiceTypeService serviceTypeService)
    {
        _serviceTypeService = serviceTypeService;
    }

    [HttpGet("getAll")]
    public ActionResult<List<ServiceTypeDTO>> GetAll()
    {
        return Ok(_serviceTypeService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(ServiceTypeDTO patient, CancellationToken cancellationToken)
    {
        return Ok(_serviceTypeService.Create(patient, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<ServiceTypeDTO> Update(ServiceTypeDTO serviceTypeDTO, CancellationToken cancellationToken)
    {
        return Ok(_serviceTypeService.Update(serviceTypeDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _serviceTypeService.Delete(id);
        return Ok(id);
    }
}
