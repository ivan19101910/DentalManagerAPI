using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IPatientService
    {
        PatientDTO GetUserById(int id);
        int CreatePatient(PatientDTO patient);
        List<PatientDTO> GetAll();
        PatientDTO Update(PatientDTO user);
        void Delete(int id);
    }
}

