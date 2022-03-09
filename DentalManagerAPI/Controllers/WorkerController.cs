using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private IWorkerService _workerService;
        private IWorkerScheduleService _workerScheduleService;
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

        //[Authorize]
        [HttpGet]
        [Route("getById/{workerId}")]
        public ActionResult<FullWorkerDTO> GetById(int workerId)
        {
            var result = _workerService.GetWorkerById(workerId);
            if (result != null)
                return result;
            else
                return NotFound();
        }
        //[Authorize]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<ShowWorkerDTO>> GetAll()
        {
            var result = _workerService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(CreateWorkerDTO worker)
        {
            try
            {
                var result = _workerService.Create(worker);
                if (result != null)
                    return result;
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<UpdateWorkerDTO> Update(UpdateWorkerDTO workerDTO)
        {
            //try
            //{
            //    var result = _workerService.Update(workerDTO);
            //    return result;
            //}
            //catch (ArgumentException ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            try
            {
                var result = _workerService.Update(workerDTO);
                //_appointmentServiceService.Update()
                if (result.WorkerSchedules == null || result.WorkerSchedules.Count == 0)
                {
                    _workerScheduleService.DeleteAllByWorkerId(result.Id);
                }
                else
                {
                    _workerScheduleService.UpdateMany(workerDTO.WorkerSchedules, result.Id);
                }
                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<int> Delete(int id)
        {
            try
            {
                _workerService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}
