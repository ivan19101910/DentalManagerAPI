using DentalManager.Application.Contracts.Offices;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("offices")]
public sealed class OfficeController : ControllerBase
{
    private IOfficeService _officeService;

    public OfficeController(IOfficeService officeService)
    {
        _officeService = officeService;
    }

    [HttpGet("get-by-id/{cityId}")]
    public ActionResult<OfficeDto> GetById(int cityId)
    {
        return Ok(_officeService.GetById(cityId));
    }

    [HttpGet("get-all")]
    public ActionResult<List<ShowOfficeDto>> GetAll()
    {
        return Ok(_officeService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(CreateOfficeDto office, CancellationToken cancellationToken)
    {
        return Ok(_officeService.Create(office, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<OfficeDto> Update(CreateOfficeDto officeDTO, CancellationToken cancellationToken)
    {
        return Ok(_officeService.Update(officeDTO, cancellationToken));
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _officeService.Delete(id);
        return Ok(id);
    }
}
