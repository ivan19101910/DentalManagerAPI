using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;
        public ApppointmentController(IAppointmentService apppointmentService)
        {
            _appointmentService = apppointmentService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<AppointmentDTO>> GetAll()
        {
            var result = _appointmentService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(AppointmentDTO appointment)
        {
            try
            {
                var result = _appointmentService.Create(appointment);
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
        public ActionResult<AppointmentDTO> UpdateUser(AppointmentDTO appointmentDTO)
        {
            try
            {
                var result = _appointmentService.Update(appointmentDTO);
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
                _appointmentService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}
