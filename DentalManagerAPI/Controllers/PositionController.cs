using DentalManager.Application.Contracts.Positions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[ApiController]
[Route("positions")]
public sealed class PositionController : ControllerBase
{
    private readonly IPositionService _positionService;

    public PositionController(IPositionService positionService)
    {
        _positionService = positionService;
    }

    [HttpGet("get-by-id/{positionId}")]
    public ActionResult<PositionDto> GetById(int positionId)
    {
        return Ok(_positionService.GetById(positionId));
    }

    [HttpGet("get-all")]
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

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _positionService.Delete(id);
        return Ok(id);
    }
}

