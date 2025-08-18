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

    [HttpGet]
    [Route("getById/{positionId}")]
    public ActionResult<PositionDTO> GetById(int positionId)
    {
        var result = _positionService.GetById(positionId);
        if (result != null)
            return result;
        else
            return NotFound();
    }

    [HttpGet]
    [Route("getAll")]
    public ActionResult<List<PositionDTO>> GetAll()
    {
        var result = _positionService.GetAll();
        if (result != null)
            return result.ToList();
        else
            return NotFound();
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<int> Create(PositionDTO position, CancellationToken cancellationToken)
    {
        var result = _positionService.Create(position, cancellationToken);
        if (result != null)
            return result;
        else
            return BadRequest();
    }
    [HttpPut]
    [Route("update")]
    public ActionResult<PositionDTO> Update(PositionDTO positionDTO, CancellationToken cancellationToken)
    {
        var result = _positionService.Update(positionDTO, cancellationToken);
        return result;
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _positionService.Delete(id);
        return id;
    }
}

