namespace DentalManager.Application.Contracts.Patients;

public interface IPatientService
{
    PatientDto GetUserById(int id);
    int CreatePatient(PatientDto patient, CancellationToken cancellationToken);
    List<PatientDto> GetAll();
    PatientDto Update(PatientDto user, CancellationToken cancellationToken);
    void Delete(int id);
}

