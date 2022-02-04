using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;
using DentalManagerAPI.Services.Abstractions;
using DentalManagerAPI.UnitOfWork.Abstractions;

namespace DentalManagerAPI.Services
{
    public class PatientService : IPatientService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PatientDTO GetUserById(int id)
        {
            var user = _unitOfWork.PatientRepository.GetById(id);

            var mappedUser = _mapper.Map<PatientDTO>(user);
            return mappedUser;

        }

        public List<PatientDTO> GetAll()
        {
            var patients = _unitOfWork.PatientRepository.GetAll();
            var mappedList = _mapper.Map<List<Patient>, List<PatientDTO>>(patients.ToList());
            return mappedList;
        }

        public int CreatePatient(PatientDTO patient)
        {
            var mappedPatient = _mapper.Map<PatientDTO, Patient>(patient);

            var newPatient = _unitOfWork.PatientRepository.Add(mappedPatient);
            _unitOfWork.Save();

            return newPatient.Id;
        }

        public PatientDTO Update(PatientDTO patient)
        {
            var updatePatient = _mapper.Map<Patient>(patient);
            var updatedPatient = _unitOfWork.PatientRepository.Edit(updatePatient);

            _unitOfWork.Save();

            var updatedUserDTO = _mapper.Map<PatientDTO>(updatedPatient);

            return updatedUserDTO;
        }

        public void Delete(int id)
        {
            var patient = _unitOfWork.PatientRepository.GetById(id);
            if (patient != null)
            {
                _unitOfWork.PatientRepository.Delete(id);
                _unitOfWork.Save();
            }
        }
    }
}
