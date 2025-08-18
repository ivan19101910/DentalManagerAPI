using DentalManager.Application.Contracts.Cities;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("cities")]
public sealed class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    [Route("get-by-id/{cityId}")]
    public ActionResult<CityDto> GetById(int cityId)
    {
        return Ok(_cityService.GetById(cityId));
    }

    [HttpGet]
    [Route("get-all")]
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
    [Route("{id}/remove")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        _cityService.Delete(id);
        return Ok(id);
    }
}
