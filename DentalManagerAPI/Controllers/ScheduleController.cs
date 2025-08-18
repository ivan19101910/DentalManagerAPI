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

    [HttpGet]
    [Route("getById/{scheduleId}")]
    public ActionResult<ScheduleDTO> GetById(int scheduleId)
    {
        var result = _scheduleService.GetById(scheduleId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<ShowScheduleDTO>> GetAll()
    {
        var result = _scheduleService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(ScheduleDTO schedule, CancellationToken cancellationToken)
    {
        var result = _scheduleService.Create(schedule, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }

    [HttpPut]
    [Route("update")]
    public ActionResult<ScheduleDTO> Update(ScheduleDTO scheduleDTO, CancellationToken cancellationToken)
    {
        var result = _scheduleService.Update(scheduleDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _scheduleService.Delete(id);
        return id;
    }
}
