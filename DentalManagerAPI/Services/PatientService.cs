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
    }
}
