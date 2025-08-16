using DentalManager.Application.Appointments;
using DentalManager.Application.Cities;
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
using DentalManager.Application.Days;
using DentalManager.Application.Offices;
using DentalManager.Application.Patients;
using DentalManager.Application.Positions;
using DentalManager.Application.Salaries;
using DentalManager.Application.Schedules;
using DentalManager.Application.Services;
using DentalManager.Application.Workers;
using DentalManager.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DentalManager.Application;

public static class ApplicationLayer
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var configuration = services.GetConfiguration();

        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        services
             .AddTransient<IAppointmentService, AppointmentService>()
             .AddTransient<IAppointmentPaymentService, AppointmentPaymentService>()
             .AddTransient<IAppointmentServiceService, AppointmentServiceService>()
             .AddTransient<IAppointmentStatusService, AppointmentStatusService>()
             .AddTransient<ICityService, CityService>()
             .AddTransient<IDayService, DayService>()
             .AddTransient<IOfficeService, OfficeService>()
             .AddTransient<IPatientService, PatientService>()
             .AddTransient<IPositionService, PositionService>()
             .AddTransient<ISalaryPaymentService, SalaryPaymentService>()
             .AddTransient<IScheduleService, ScheduleService>()
             .AddTransient<ITimeSegmentService, TimeSegmentService>()
             .AddTransient<IServiceService, ServiceService>()
             .AddTransient<IServiceTypeService, ServiceTypeService>()
             .AddTransient<IWorkerService, WorkerService>()
             .AddTransient<IWorkerScheduleService, WorkerScheduleService>();

        services.AddAutoMapper(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        return services;
    }
}
