using DentalManagerAPI.DTOs;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
namespace DentalManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    { 
        private IPatientService _patientService;
        public PatientController(IPatientService accountService)
        {
            _patientService = accountService;
        }

        [HttpGet]
        [Route("get-by-id/{patientId}")]
        public ActionResult<PatientDTO> GetById(int patientId)
        {
            var result = _patientService.GetUserById(patientId);
            if (result != null)
                return result;
            else
                return NotFound();
        }
    }
}
