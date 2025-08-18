using DentalManager.Application.Contracts.Schedules;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet("getById/{scheduleId}")]
    public ActionResult<ScheduleDTO> GetById(int scheduleId)
    {
        return Ok(_scheduleService.GetById(scheduleId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<ShowScheduleDTO>> GetAll()
    {
        return Ok(_scheduleService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(ScheduleDTO schedule, CancellationToken cancellationToken)
    {
        return Ok(_scheduleService.Create(schedule, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<ScheduleDTO> Update(ScheduleDTO scheduleDTO, CancellationToken cancellationToken)
    {
        return Ok(_scheduleService.Update(scheduleDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _scheduleService.Delete(id);
        return Ok(id);
    }
}
