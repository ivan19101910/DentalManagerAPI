using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentPaymentController : ControllerBase
    {
        private IAppointmentPaymentService _appointmentPaymentService;
        public AppointmentPaymentController(IAppointmentPaymentService appointmentPaymentService)
        {
            _appointmentPaymentService = appointmentPaymentService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<AppointmentPaymentDTO>> GetAll()
        {
            var result = _appointmentPaymentService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(AppointmentPaymentDTO patient)
        {
            try
            {
                var result = _appointmentPaymentService.Create(patient);
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
        public ActionResult<AppointmentPaymentDTO> Update(AppointmentPaymentDTO appointmentPaymentDTO)
        {
            try
            {
                var result = _appointmentPaymentService.Update(appointmentPaymentDTO);
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
                _appointmentPaymentService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    }
}


