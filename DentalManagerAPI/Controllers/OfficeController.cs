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

    [HttpGet]
    [Route("getById/{cityId}")]
    public ActionResult<OfficeDTO> GetById(int cityId)
    {
        var result = _officeService.GetById(cityId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<ShowOfficeDTO>> GetAll()
    {
        var result = _officeService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(CreateOfficeDTO office, CancellationToken cancellationToken)
    {
        var result = _officeService.Create(office, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }

    [HttpPut]
    [Route("update")]
    public ActionResult<OfficeDTO> Update(CreateOfficeDTO officeDTO, CancellationToken cancellationToken)
    {
        var result = _officeService.Update(officeDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _officeService.Delete(id);
        return id;
    }
}
