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
    
    [HttpGet("get-by-id/{patientId}")]
    public ActionResult<PatientDTO> GetById(int patientId)
    {
        return Ok(_patientService.GetUserById(patientId));
    }
    
    [HttpGet("getAll")]
    public ActionResult<List<PatientDTO>> GetAll()
    {
        return Ok(_patientService.GetAll());
    }

    [HttpPost("create")]
    public ActionResult<int> Create(PatientDTO patient, CancellationToken cancellationToken)
    {
        return Ok(_patientService.CreatePatient(patient, cancellationToken));
    }
    
    [HttpPut("update")]
    public ActionResult<PatientDTO> Update(PatientDTO patientDTO, CancellationToken cancellationToken)
    {
        return Ok(_patientService.Update(patientDTO, cancellationToken));
    }

    [HttpDelete("delete/{id}")]
    public ActionResult<int> Delete(int id)
    {
        _patientService.Delete(id);
        return Ok(id);
    }
} 
