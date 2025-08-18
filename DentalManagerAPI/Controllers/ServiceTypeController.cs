using DentalManager.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("service-types")]
public sealed class ServiceTypeController : ControllerBase
{
    private readonly IServiceTypeService _serviceTypeService;

    public ServiceTypeController(IServiceTypeService serviceTypeService)
    {
        _serviceTypeService = serviceTypeService;
    }

    [HttpGet("get-all")]
    public ActionResult<List<ServiceTypeDto>> GetAll()
    {
        return Ok(_serviceTypeService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(ServiceTypeDto patient, CancellationToken cancellationToken)
    {
        return Ok(_serviceTypeService.Create(patient, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<ServiceTypeDto> Update(ServiceTypeDto serviceTypeDTO, CancellationToken cancellationToken)
    {
        return Ok(_serviceTypeService.Update(serviceTypeDTO, cancellationToken));
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _serviceTypeService.Delete(id);
        return Ok(id);
    }
}
