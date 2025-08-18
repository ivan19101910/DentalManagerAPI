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

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<ServiceTypeDTO>> GetAll()
    {
        var result = _serviceTypeService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(ServiceTypeDTO patient, CancellationToken cancellationToken)
    {
        var result = _serviceTypeService.Create(patient, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }
    [HttpPut]
    [Route("update")]
    public ActionResult<ServiceTypeDTO> Update(ServiceTypeDTO serviceTypeDTO, CancellationToken cancellationToken)
    {
        var result = _serviceTypeService.Update(serviceTypeDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _serviceTypeService.Delete(id);
        return id;
    }
}
