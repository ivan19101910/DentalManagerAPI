using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        [Authorize]
        [HttpGet]
        [Route("get-by-id/{workerId}")]
        public ActionResult<WorkerDTO> GetById(int workerId)
        {
            var result = _workerService.GetWorkerById(workerId);
            if (result != null)
                return result;
            else
                return NotFound();
        }
        [Authorize]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<WorkerDTO>> GetAll()
        {
            var result = _workerService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }
    }
}
