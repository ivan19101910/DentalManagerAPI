using DentalManagerAPI.DTOs;

namespace DentalManagerAPI.Services.Abstractions
{
    public interface IPatientService
    {
        PatientDTO GetUserById(int id);

        List<PatientDTO> GetAll();
    }
}

