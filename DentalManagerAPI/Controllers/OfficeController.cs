using DentalManager.Application.Contracts.Offices;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class OfficeController : ControllerBase
{
    private IOfficeService _officeService;

    public OfficeController(IOfficeService officeService)
    {
        _officeService = officeService;
    }

    [HttpGet("getById/{cityId}")]
    public ActionResult<OfficeDTO> GetById(int cityId)
    {
        return Ok(_officeService.GetById(cityId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<ShowOfficeDTO>> GetAll()
    {
        return Ok(_officeService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(CreateOfficeDTO office, CancellationToken cancellationToken)
    {
        return Ok(_officeService.Create(office, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<OfficeDTO> Update(CreateOfficeDTO officeDTO, CancellationToken cancellationToken)
    {
        return Ok(_officeService.Update(officeDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _officeService.Delete(id);
        return Ok(id);
    }
}
