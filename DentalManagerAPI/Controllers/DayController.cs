using DentalManager.Application.Contracts.Days;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class DayController : ControllerBase
{
    private readonly IDayService _dayService;

    public DayController(IDayService dayService)
    {
        _dayService = dayService;
    }

    [HttpGet("getAll")]
    public ActionResult<List<DayDTO>> GetAll()
    {
        return Ok(_dayService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(DayDTO day, CancellationToken cancellationToken)
    {
        return Ok(_dayService.Create(day, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<DayDTO> Update(DayDTO dayDTO, CancellationToken cancellationToken)
    {
        return Ok(_dayService.Update(dayDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _dayService.Delete(id);
        return Ok(id);
    }
}
