using AutoMapper;
using DentalManager.Application.Contracts.Patients;
using DentalManager.Domain.Patients;

namespace DentalManager.Application.Patients;

public sealed class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public PatientDTO GetUserById(int id)
    {
        var user = _patientRepository.GetById(id);
        var mappedUser = _mapper.Map<PatientDTO>(user);

        return mappedUser;
    }

    public List<PatientDTO> GetAll()
    {
        var patients = _patientRepository.GetAll();
        var mappedList = _mapper.Map<List<Patient>, List<PatientDTO>>(patients.ToList());

        return mappedList;
    }

    public int CreatePatient(PatientDTO patient, CancellationToken cancellationToken)
    {
        var mappedPatient = _mapper.Map<PatientDTO, Patient>(patient);
        var newPatient = _patientRepository.Add(mappedPatient, cancellationToken);

        return newPatient.Id;
    }

    public PatientDTO Update(PatientDTO patient, CancellationToken cancellationToken)
    {
        var updatePatient = _mapper.Map<Patient>(patient);
        var updatedPatient = _patientRepository.Update(updatePatient, cancellationToken);
        var updatedUserDTO = _mapper.Map<PatientDTO>(updatedPatient);

        return updatedUserDTO;
    }

    public void Delete(int id)
    {
        var patient = _patientRepository.GetById(id);

        if (patient != null)
        {
            _patientRepository.Delete(id);
        }
    }
}
