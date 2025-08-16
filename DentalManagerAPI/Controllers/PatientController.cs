using DentalManager.Api.Helpers;
using DentalManager.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public sealed class PatientController : ControllerBase
{ 
    private readonly IPatientService _patientService;
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
