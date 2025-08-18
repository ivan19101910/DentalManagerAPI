using DentalManager.Application.Contracts.Workers;
using DentalManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
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

    [HttpGet("getById/{workerId}")]
    public ActionResult<FullWorkerDTO> GetById(int workerId)
    {
        return Ok(_workerService.GetWorkerById(workerId));
    }

    [HttpGet("getSalaryById/{workerId}/{monthNumber}/{year}")]
    public ActionResult<decimal> GetSalaryById(int workerId, int monthNumber, int year)
    {
        return Ok(_workerService.CalculateSalaryByWorkerId(workerId, monthNumber, year));
    }

    [HttpGet("getByNameSurname/{name}/{surname}")]
    public ActionResult<List<FullWorkerDTO>> GetWorkersByNameSurname(string name, string surname)
    {
        return Ok(_workerService.GetWorkersByNameSurname(name, surname));
    }

    [HttpGet("getByAddress/{city}/{address}")]
    public ActionResult<List<FullWorkerDTO>> GetWorkersByAddress(string city, string address)
    {
        return Ok(_workerService.GetWorkersByAddress(city, address));
    }

    [HttpGet("getAll")]
    public ActionResult<List<ShowWorkerDTO>> GetAll()
    {
        return Ok(_workerService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(CreateWorkerDTO worker, CancellationToken cancellationToken)
    {
        return Ok(_workerService.Create(worker, cancellationToken));
    }

    [HttpPut("update")]
    public ActionResult<UpdateWorkerDTO> Update(UpdateWorkerDTO workerDTO, CancellationToken cancellationToken)
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

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _workerService.Delete(id);
        return Ok(id);
    }
}
