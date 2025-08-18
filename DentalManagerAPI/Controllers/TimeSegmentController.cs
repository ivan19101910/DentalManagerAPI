using DentalManager.Application.Contracts.Schedules;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TimeSegmentController : ControllerBase
{
    private readonly ITimeSegmentService _timeSegmentService;

    public TimeSegmentController(ITimeSegmentService timeSegmentService)
    {
        _timeSegmentService = timeSegmentService;
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<TimeSegmentDTO>> GetAll()
    {
        var result = _timeSegmentService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(TimeSegmentDTO timeSegment, CancellationToken cancellationToken)
    {
        var result = _timeSegmentService.Create(timeSegment, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }

    [HttpPut]
    [Route("update")]
    public ActionResult<TimeSegmentDTO> Update(TimeSegmentDTO timeSegmentDTO, CancellationToken cancellationToken)
    {
        var result = _timeSegmentService.Update(timeSegmentDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _timeSegmentService.Delete(id);
        return id;
    }
}
