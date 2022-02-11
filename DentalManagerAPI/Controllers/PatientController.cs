using DentalManagerAPI.DTOs;
using DentalManagerAPI.Helpers;
using DentalManagerAPI.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

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
        //[Authorize]
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
        //[Authorize]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<PatientDTO>> GetAll()
        {
            var result = _patientService.GetAll();
            if (result != null)
                return result.ToList();
            else
                return NotFound();
        }

        //[Authorize]
        [HttpPost]
        [Route("create")]
        public ActionResult<int> Create(PatientDTO patient)
        {            
            try
            {
                var result = _patientService.CreatePatient(patient);
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
        //[Authorize]
        [HttpPut]
        [Route("update")]
        public ActionResult<PatientDTO> Update(PatientDTO patientDTO)
        {
            try
            {
                var result = _patientService.Update(patientDTO);
                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<int> Delete(int id)
        {
            try
            {
                _patientService.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return id;
        }
    } 
}

