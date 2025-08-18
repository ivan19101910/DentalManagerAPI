using DentalManager.Application.Contracts.Days;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("days")]
public sealed class DayController : ControllerBase
{
    private readonly IDayService _dayService;

    public DayController(IDayService dayService)
    {
        _dayService = dayService;
    }

    [HttpGet("get-all")]
    public ActionResult<List<DayDto>> GetAll()
    {
        return Ok(_dayService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(DayDto day, CancellationToken cancellationToken)
    {
        return Ok(_dayService.Create(day, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<DayDto> Update(DayDto dayDTO, CancellationToken cancellationToken)
    {
        return Ok(_dayService.Update(dayDTO, cancellationToken));
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _dayService.Delete(id);
        return Ok(id);
    }
}
