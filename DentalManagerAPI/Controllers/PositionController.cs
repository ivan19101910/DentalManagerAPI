using DentalManager.Application.Contracts.Positions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpGet("getById/{positionId}")]
    public ActionResult<PositionDto> GetById(int positionId)
    {
        return Ok(_positionService.GetById(positionId));
    }

    [HttpGet("getAll")]
    public ActionResult<List<PositionDto>> GetAll()
    {
        return Ok(_positionService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(PositionDto position, CancellationToken cancellationToken)
    {
        return Ok(_positionService.Create(position, cancellationToken));
    }
    [HttpPut("update")]
    public ActionResult<PositionDto> Update(PositionDto positionDTO, CancellationToken cancellationToken)
    {
        return Ok(_positionService.Update(positionDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _positionService.Delete(id);
        return Ok(id);
    }
}

