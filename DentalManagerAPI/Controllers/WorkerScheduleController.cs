using DentalManager.Application.Contracts.Workers;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class WorkerScheduleController : ControllerBase
{
    private readonly IWorkerScheduleService _workerScheduleService;

    public WorkerScheduleController(IWorkerScheduleService workerScheduleService)
    {
        _workerScheduleService = workerScheduleService;
    }

    [HttpGet("getById/{scheduleId}")]
    public ActionResult<WorkerScheduleDto> GetById(int scheduleId)
    {
        return Ok(_workerScheduleService.GetById(scheduleId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<WorkerScheduleDto>> GetAll()
    {
        return Ok(_workerScheduleService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(WorkerScheduleDto schedule, CancellationToken cancellationToken)
    {
        return Ok(_workerScheduleService.Create(schedule, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<WorkerScheduleDto> Update(WorkerScheduleDto scheduleDTO, CancellationToken cancellationToken)
    {
        return Ok(_workerScheduleService.Update(scheduleDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _workerScheduleService.Delete(id);
        return Ok(id);
    }
}
