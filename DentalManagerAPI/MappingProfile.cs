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
            CreateMap<SalaryPayment, SalaryPaymentDTO>()
                .ForMember("WorkerName", opt => opt.MapFrom(x => x.Worker.FirstName))
                .ForMember("WorkerSurname", opt => opt.MapFrom(x => x.Worker.LastName));
            CreateMap<CreateSalaryPaymentDTO, SalaryPayment>().ReverseMap();
            CreateMap<SalaryPaymentDTO, SalaryPayment>();
            CreateMap<Day, DayDTO>().ReverseMap();
            CreateMap<TimeSegment, TimeSegmentDTO>().ReverseMap();
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Worker, ShowWorkerDTO>()
                .ForMember("City", opt => opt.MapFrom(x => x.Office.City.Name))
                .ForMember("PositionName", opt => opt.MapFrom(x => x.Position.PositionName));
            CreateMap<Office, ShowOfficeDTO>()
                .ForMember("CityName", opt => opt.MapFrom(x => x.City.Name));
            CreateMap<CreateOfficeDTO, Office>();
            CreateMap<CreateWorkerDTO, Worker>();
            CreateMap<Worker, FullWorkerDTO>()
                .ForMember("OfficeCity", opt => opt.MapFrom(x => x.Office.City.Name))
                .ForMember("OfficeAddress", opt => opt.MapFrom(x => x.Office.Address))
                .ForMember("PositionName", opt => opt.MapFrom(x => x.Position.PositionName));
            CreateMap<Appointment, ShortAppointmentDTO>()
                .ForMember("PatientName", opt => opt.MapFrom(x => x.Patient.FirstName))
                .ForMember("PatientSurname", opt => opt.MapFrom(x => x.Patient.LastName))
                .ForMember("WorkerName", opt => opt.MapFrom(x => x.Worker.FirstName))
                .ForMember("WorkerSurname", opt => opt.MapFrom(x => x.Worker.LastName));
            CreateMap<UpdateWorkerDTO, Worker>().ReverseMap();
            CreateMap<CreateAppointmentDTO, Appointment>();
            //.ForMember("AppointmentTime", opt => opt.MapFrom(x => TimeSpan.Parse(x.AppointmentDate))
            //.ForMember("RealEndTime");
            CreateMap<AppointmentServiceDTO, AppointmentService>();
            CreateMap<AppointmentService, AppointmentServiceDTO>()
                .ForMember("ServiceName", opt => opt.MapFrom(x => x.Service.Name))
                .ForMember("ServicePrice", opt => opt.MapFrom(x => x.Service.Price));
            CreateMap<FullAppointmentDTO, Appointment>().ReverseMap();
            CreateMap<EditAppointmentDTO, Appointment>().ReverseMap();
        }
     
    }
}
