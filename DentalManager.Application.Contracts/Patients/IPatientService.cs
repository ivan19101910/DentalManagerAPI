namespace DentalManager.Application.Contracts.Patients;

public interface IPatientService
{
    PatientDTO GetUserById(int id);
    int CreatePatient(PatientDTO patient, CancellationToken cancellationToken);
    List<PatientDTO> GetAll();
    PatientDTO Update(PatientDTO user, CancellationToken cancellationToken);
    void Delete(int id);
}

