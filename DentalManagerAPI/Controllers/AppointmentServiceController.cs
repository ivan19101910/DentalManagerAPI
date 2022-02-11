using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentServiceController : ControllerBase
    {
        private IAppointmentServiceService _appointmentServiceService;

        public AppointmentServiceController(IAppointmentServiceService appointmentServiceService)
        {
            _appointmentServiceService = appointmentServiceService;
        }

        //[HttpPost]
        //[Route("createMany")]
        //public ActionResult<List<int>> CreateMany(List<AppointmentServiceDTO> appointment)
        //{
        //    try
        //    {
        //        var result = _appointmentServiceService.CreateMany(appointment);
        //        if (result != null)
        //            return result;
        //        else
        //            return BadRequest();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
