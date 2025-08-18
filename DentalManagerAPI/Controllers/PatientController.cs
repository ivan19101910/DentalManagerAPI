using DentalManager.Api.Helpers;
using DentalManager.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace DentalManager.Api.Controllers;

[Authorize]
[ApiController]
[Route("patients")]
public sealed class PatientController : ControllerBase
{ 
    private readonly IPatientService _patientService;
    public PatientController(IPatientService accountService)
    {
        _patientService = accountService;
    }
    
    [HttpGet("get-by-id/{patientId}")]
    public ActionResult<PatientDto> GetById(int patientId)
    {
        return Ok(_patientService.GetUserById(patientId));
    }
    
    [HttpGet("get-all")]
    public ActionResult<List<PatientDto>> GetAll()
    {
        return Ok(_patientService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(PatientDto patient, CancellationToken cancellationToken)
    {
        return Ok(_patientService.CreatePatient(patient, cancellationToken));
    }
    
    [HttpPut("update")]
    public ActionResult<PatientDto> Update(PatientDto patientDTO, CancellationToken cancellationToken)
    {
        return Ok(_patientService.Update(patientDTO, cancellationToken));
    }

    [HttpDelete("{id}/remove")]
    public ActionResult<int> Delete(int id)
    {
        _patientService.Delete(id);
        return Ok(id);
    }
} 
