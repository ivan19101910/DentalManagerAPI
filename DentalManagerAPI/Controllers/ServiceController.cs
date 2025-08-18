using DentalManager.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet("get-by-id/{serviceId}")]
    public ActionResult<ServiceDto> GetById(int serviceId)
    {
        return Ok(_serviceService.GetById(serviceId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<ServiceDto>> GetAll()
    {
        return Ok(_serviceService.GetAll());
    }

    [HttpGet("getByServiceType/{serviceType}")]
    public ActionResult<List<ServiceDto>> GetWorkersByAddress(string serviceType)
    {
        return Ok(_serviceService.GetByServiceType(serviceType));
    }

    [HttpPost("create")]
    public ActionResult<int> Create(ServiceDto patient, CancellationToken cancellationToken)
    {
        return Ok(_serviceService.Create(patient, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<ServiceDto> Update(ServiceDto serviceDTO, CancellationToken cancellationToken)
    {
        return Ok(_serviceService.Update(serviceDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _serviceService.Delete(id);
        return Ok(id);
    }
}

