using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;

namespace DentalManagerAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<Worker, WorkerDTO>();
        }
     
    }
}
