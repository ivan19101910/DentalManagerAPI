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
    public ActionResult<WorkerScheduleDTO> GetById(int scheduleId)
    {
        return Ok(_workerScheduleService.GetById(scheduleId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<WorkerScheduleDTO>> GetAll()
    {
        return Ok(_workerScheduleService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(WorkerScheduleDTO schedule, CancellationToken cancellationToken)
    {
        return Ok(_workerScheduleService.Create(schedule, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<WorkerScheduleDTO> Update(WorkerScheduleDTO scheduleDTO, CancellationToken cancellationToken)
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
