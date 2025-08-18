using DentalManager.Application.Contracts.Days;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DayController : ControllerBase
{
    private readonly IDayService _dayService;

    public DayController(IDayService dayService)
    {
        _dayService = dayService;
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<DayDTO>> GetAll()
    {
        var result = _dayService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(DayDTO day, CancellationToken cancellationToken)
    {
        var result = _dayService.Create(day, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }
    [HttpPut]
    [Route("update")]
    public ActionResult<DayDTO> Update(DayDTO dayDTO, CancellationToken cancellationToken)
    {
        var result = _dayService.Update(dayDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _dayService.Delete(id);
        return id;
    }
}
