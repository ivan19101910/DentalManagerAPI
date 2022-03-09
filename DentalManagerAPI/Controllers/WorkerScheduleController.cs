using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerScheduleController : ControllerBase
    {
        private IWorkerScheduleService _workerScheduleService;
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
        public ActionResult<int> Create(WorkerScheduleDTO schedule)
        {
            try
            {
                var result = _workerScheduleService.Create(schedule);
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
        public ActionResult<WorkerScheduleDTO> Update(WorkerScheduleDTO scheduleDTO)
        {
            try
            {
                var result = _workerScheduleService.Update(scheduleDTO);
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
                _workerScheduleService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}
