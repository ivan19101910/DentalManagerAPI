using DentalManager.Application.Contracts.Schedules;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("time-segments")]
public sealed class TimeSegmentController : ControllerBase
{
    private readonly ITimeSegmentService _timeSegmentService;

    public TimeSegmentController(ITimeSegmentService timeSegmentService)
    {
        _timeSegmentService = timeSegmentService;
    }

    [HttpGet("get-all")]
    public ActionResult<List<TimeSegmentDto>> GetAll()
    {
        return Ok(_timeSegmentService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(TimeSegmentDto timeSegment, CancellationToken cancellationToken)
    {
        return Ok(_timeSegmentService.Create(timeSegment, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<TimeSegmentDto> Update(TimeSegmentDto timeSegmentDTO, CancellationToken cancellationToken)
    {
        return Ok(_timeSegmentService.Update(timeSegmentDTO, cancellationToken));
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _timeSegmentService.Delete(id);
        return Ok(id);
    }
}
