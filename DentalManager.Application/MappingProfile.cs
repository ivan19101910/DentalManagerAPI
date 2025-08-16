using AutoMapper;
using DentalManager.Application.Contracts.Appointments;
using DentalManager.Application.Contracts.Cities;
using DentalManager.Application.Contracts.Days;
using DentalManager.Application.Contracts.Offices;
using DentalManager.Application.Contracts.Patients;
using DentalManager.Application.Contracts.Positions;
using DentalManager.Application.Contracts.Salaries;
using DentalManager.Application.Contracts.Schedules;
using DentalManager.Application.Contracts.Services;
using DentalManager.Application.Contracts.Workers;
using DentalManager.Domain.Appointments;
using DentalManager.Domain.Cities;
using DentalManager.Domain.Days;
using DentalManager.Domain.Offices;
using DentalManager.Domain.Patients;
using DentalManager.Domain.Positions;
using DentalManager.Domain.Salaries;
using DentalManager.Domain.Schedules;
using DentalManager.Domain.Services;
using DentalManager.Domain.Workers;

namespace DentalManager.Application;

public sealed class MappingProfile : Profile
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
        CreateMap<Schedule, ShowScheduleDTO>()
            .ForMember("Day", opt => opt.MapFrom(x => x.Day.Name))
            .ForMember("TimeStart", opt => opt.MapFrom(x => x.TimeSegment.TimeStart))
            .ForMember("TimeEnd", opt => opt.MapFrom(x => x.TimeSegment.TimeEnd));
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
        CreateMap<AppointmentServiceDTO, AppointmentService>();
        CreateMap<AppointmentService, AppointmentServiceDTO>()
            .ForMember("ServiceName", opt => opt.MapFrom(x => x.Service.Name))
            .ForMember("ServicePrice", opt => opt.MapFrom(x => x.Service.Price));
        CreateMap<FullAppointmentDTO, Appointment>().ReverseMap();
        CreateMap<EditAppointmentDTO, Appointment>().ReverseMap();

        CreateMap<WorkerSchedule, WorkerScheduleDTO>().ReverseMap();
        CreateMap<WorkerSchedule, WorkerScheduleByIdDTO>()
            .ForMember("Day", opt => opt.MapFrom(x => x.Schedule.Day.Name))
            .ForMember("TimeStart", opt => opt.MapFrom(x => x.Schedule.TimeSegment.TimeStart))
            .ForMember("TimeEnd", opt => opt.MapFrom(x => x.Schedule.TimeSegment.TimeEnd));
    }
}
