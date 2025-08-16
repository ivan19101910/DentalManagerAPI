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

    [HttpGet]
    [Route("get-by-id/{serviceId}")]
    public ActionResult<ServiceDTO> GetById(int serviceId)
    {
        var result = _serviceService.GetById(serviceId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<ServiceDTO>> GetAll()
    {
        var result = _serviceService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getByServiceType/{serviceType}")]
    public ActionResult<List<ServiceDTO>> GetWorkersByAddress(string serviceType)
    {
        var result = _serviceService.GetByServiceType(serviceType);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(ServiceDTO patient)
    {
        try
        {
            var result = _serviceService.Create(patient);
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
    public ActionResult<ServiceDTO> Update(ServiceDTO serviceDTO)
    {
        try
        {
            var result = _serviceService.Update(serviceDTO);
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
            _serviceService.Delete(id);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        return id;
    }
}

