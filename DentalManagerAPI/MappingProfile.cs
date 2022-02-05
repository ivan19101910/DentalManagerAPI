using AutoMapper;
using DentalManagerAPI.DTOs;
using DentalManagerAPI.Models;

namespace DentalManagerAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Worker, WorkerDTO>();
            CreateMap<ServiceType, ServiceTypeDTO>().ReverseMap();
                
            CreateMap<Service, ServiceDTO>()
                .ForMember("ServiceTypeName", opt => opt.MapFrom(c => c.ServiceType.Name));
            CreateMap<ServiceDTO, Service>();
            CreateMap<Office, OfficeDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<AppointmentPayment, AppointmentPaymentDTO>().ReverseMap();
            CreateMap<AppointmentStatus, AppointmentStatusDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<SalaryPayment, SalaryPaymentDTO>().ReverseMap();
        }
     
    }
}
