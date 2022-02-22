using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentStatusController : ControllerBase
    {
        private IAppointmentStatusService _appointmentStatusService;
        public AppointmentStatusController(IAppointmentStatusService appointmentStatusService)
        {
            _appointmentStatusService = appointmentStatusService;
        }

        [HttpGet]
        [Route("getById/{statusId}")]
        public ActionResult<AppointmentStatusDTO> GetById(int statusId)
        {
            var result = _appointmentStatusService.GetById(statusId);
            if (result != null)
                return result;
            else
                return NotFound();
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<AppointmentStatusDTO>> GetAll()
        {
            var result = _appointmentStatusService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(AppointmentStatusDTO patient)
        {
            try
            {
                var result = _appointmentStatusService.Create(patient);
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
        public ActionResult<AppointmentStatusDTO> Update(AppointmentStatusDTO appointmentStatusDTO)
        {
            try
            {
                var result = _appointmentStatusService.Update(appointmentStatusDTO);
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
                _appointmentStatusService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}

