using DentalManager.Application.Contracts.Cities;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    [Route("getById/{cityId}")]
    public ActionResult<CityDto> GetById(int cityId)
    {
        return Ok(_cityService.GetById(cityId));
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<CityDto>> GetAll()
    {
        return Ok(_cityService.GetAll());
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(CityDto patient, CancellationToken cancellationToken)
    {
        return Ok(_cityService.Create(patient, cancellationToken));
    }

    [HttpPut]
    [Route("update")]
    public ActionResult<CityDto> Update(CityDto serviceDTO, CancellationToken cancellationToken)
    {
        return Ok(_cityService.Update(serviceDTO, cancellationToken));
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        _cityService.Delete(id);
        return Ok(id);
    }
}
