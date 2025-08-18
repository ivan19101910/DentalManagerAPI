using DentalManager.Application.Contracts.Workers;
using DentalManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("workers")]
public sealed class WorkerController : ControllerBase
{
    private readonly IWorkerService _workerService;

    private readonly IWorkerScheduleService _workerScheduleService;

    public WorkerController(IWorkerService workerService, IWorkerScheduleService workerScheduleService)
    {
        _workerService = workerService;
        _workerScheduleService = workerScheduleService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _workerService.Authenticate(model);
        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });
        return Ok(response);
    }

    [HttpGet("get-by-id/{workerId}")]
    public ActionResult<FullWorkerDto> GetById(int workerId)
    {
        return Ok(_workerService.GetWorkerById(workerId));
    }

    [HttpGet("get-salary-by-id/{workerId}/{monthNumber}/{year}")]
    public ActionResult<decimal> GetSalaryById(int workerId, int monthNumber, int year)
    {
        return Ok(_workerService.CalculateSalaryByWorkerId(workerId, monthNumber, year));
    }

    [HttpGet("get-by-name-surname/{name}/{surname}")]
    public ActionResult<List<FullWorkerDto>> GetWorkersByNameSurname(string name, string surname)
    {
        return Ok(_workerService.GetWorkersByNameSurname(name, surname));
    }

    [HttpGet("get-by-address/{city}/{address}")]
    public ActionResult<List<FullWorkerDto>> GetWorkersByAddress(string city, string address)
    {
        return Ok(_workerService.GetWorkersByAddress(city, address));
    }

    [HttpGet("get-all")]
    public ActionResult<List<ShowWorkerDto>> GetAll()
    {
        return Ok(_workerService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(CreateWorkerDto worker, CancellationToken cancellationToken)
    {
        return Ok(_workerService.Create(worker, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<UpdateWorkerDto> Update(UpdateWorkerDto workerDTO, CancellationToken cancellationToken)
    {
        var result = _workerService.Update(workerDTO, cancellationToken);

        if (result.WorkerSchedules == null || result.WorkerSchedules.Count == 0)
        {
            _workerScheduleService.DeleteAllByWorkerId(result.Id);
        }
        else
        {
            _workerScheduleService.UpdateMany(workerDTO.WorkerSchedules, result.Id, cancellationToken);
        }

        return Ok(result);
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _workerService.Delete(id);
        return Ok(id);
    }
}
