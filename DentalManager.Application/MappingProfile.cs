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
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<Worker, WorkerDto>();
        CreateMap<ServiceType, ServiceTypeDto>().ReverseMap();
            
        CreateMap<Service, ServiceDto>()
            .ForMember("ServiceTypeName", opt => opt.MapFrom(c => c.ServiceType.Name));
        CreateMap<ServiceDto, Service>();
        CreateMap<Office, OfficeDto>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<AppointmentPayment, AppointmentPaymentDto>().ReverseMap();
        CreateMap<AppointmentStatus, AppointmentStatusDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Position, PositionDto>().ReverseMap();
        CreateMap<SalaryPayment, SalaryPaymentDto>()
            .ForMember("WorkerName", opt => opt.MapFrom(x => x.Worker.FirstName))
            .ForMember("WorkerSurname", opt => opt.MapFrom(x => x.Worker.LastName));
        CreateMap<CreateSalaryPaymentDto, SalaryPayment>().ReverseMap();
        CreateMap<SalaryPaymentDto, SalaryPayment>();
        CreateMap<Day, DayDto>().ReverseMap();
        CreateMap<TimeSegment, TimeSegmentDto>().ReverseMap();
        CreateMap<Schedule, ScheduleDto>().ReverseMap();
        CreateMap<Schedule, ShowScheduleDto>()
            .ForMember("Day", opt => opt.MapFrom(x => x.Day.Name))
            .ForMember("TimeStart", opt => opt.MapFrom(x => x.TimeSegment.TimeStart))
            .ForMember("TimeEnd", opt => opt.MapFrom(x => x.TimeSegment.TimeEnd));
        CreateMap<Worker, ShowWorkerDto>()
            .ForMember("City", opt => opt.MapFrom(x => x.Office.City.Name))
            .ForMember("PositionName", opt => opt.MapFrom(x => x.Position.PositionName));
        CreateMap<Office, ShowOfficeDto>()
            .ForMember("CityName", opt => opt.MapFrom(x => x.City.Name));
        CreateMap<CreateOfficeDto, Office>();
        CreateMap<CreateWorkerDto, Worker>();
        CreateMap<Worker, FullWorkerDto>()
            .ForMember("OfficeCity", opt => opt.MapFrom(x => x.Office.City.Name))
            .ForMember("OfficeAddress", opt => opt.MapFrom(x => x.Office.Address))
            .ForMember("PositionName", opt => opt.MapFrom(x => x.Position.PositionName));
        CreateMap<Appointment, ShortAppointmentDto>()
            .ForMember("PatientName", opt => opt.MapFrom(x => x.Patient.FirstName))
            .ForMember("PatientSurname", opt => opt.MapFrom(x => x.Patient.LastName))
            .ForMember("WorkerName", opt => opt.MapFrom(x => x.Worker.FirstName))
            .ForMember("WorkerSurname", opt => opt.MapFrom(x => x.Worker.LastName));
        CreateMap<UpdateWorkerDto, Worker>().ReverseMap();
        CreateMap<CreateAppointmentDto, Appointment>();
        CreateMap<AppointmentServiceDto, AppointmentService>();
        CreateMap<AppointmentService, AppointmentServiceDto>()
            .ForMember("ServiceName", opt => opt.MapFrom(x => x.Service.Name))
            .ForMember("ServicePrice", opt => opt.MapFrom(x => x.Service.Price));
        CreateMap<FullAppointmentDto, Appointment>().ReverseMap();
        CreateMap<EditAppointmentDto, Appointment>().ReverseMap();

        CreateMap<WorkerSchedule, WorkerScheduleDto>().ReverseMap();
        CreateMap<WorkerSchedule, WorkerScheduleByIdDto>()
            .ForMember("Day", opt => opt.MapFrom(x => x.Schedule.Day.Name))
            .ForMember("TimeStart", opt => opt.MapFrom(x => x.Schedule.TimeSegment.TimeStart))
            .ForMember("TimeEnd", opt => opt.MapFrom(x => x.Schedule.TimeSegment.TimeEnd));
    }
}
