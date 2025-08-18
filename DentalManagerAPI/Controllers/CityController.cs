using DentalManager.Application.Contracts.Cities;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    [Route("getById/{cityId}")]
    public ActionResult<CityDTO> GetById(int cityId)
    {
        var result = _cityService.GetById(cityId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<CityDTO>> GetAll()
    {
        var result = _cityService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(CityDTO patient, CancellationToken cancellationToken)
    {
        var result = _cityService.Create(patient, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }
    [HttpPut]
    [Route("update")]
    public ActionResult<CityDTO> Update(CityDTO serviceDTO, CancellationToken cancellationToken)
    {
        var result = _cityService.Update(serviceDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _cityService.Delete(id);
        return id;
    }
}
