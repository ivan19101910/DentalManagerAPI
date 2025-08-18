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

    [HttpGet]
    [Route("getById/{scheduleId}")]
    public ActionResult<WorkerScheduleDTO> GetById(int scheduleId)
    {
        var result = _workerScheduleService.GetById(scheduleId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<WorkerScheduleDTO>> GetAll()
    {
        var result = _workerScheduleService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(WorkerScheduleDTO schedule, CancellationToken cancellationToken)
    {
        var result = _workerScheduleService.Create(schedule, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }

    [HttpPut]
    [Route("update")]
    public ActionResult<WorkerScheduleDTO> Update(WorkerScheduleDTO scheduleDTO, CancellationToken cancellationToken)
    {
        var result = _workerScheduleService.Update(scheduleDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _workerScheduleService.Delete(id);
        return id;
    }
}
