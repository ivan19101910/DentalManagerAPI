using DentalManager.Common.Extensions;
using DentalManager.Data.Appointments;
using DentalManager.Data.Cities;
using DentalManager.Data.Days;
using DentalManager.Data.Offices;
using DentalManager.Data.Patients;
using DentalManager.Data.Positions;
using DentalManager.Data.Salaries;
using DentalManager.Data.Schedules;
using DentalManager.Data.Services;
using DentalManager.Data.Workers;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalManager.Data;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
    {
        var configuration = services.GetConfiguration();

        var connection = configuration.GetConnectionString("DatabaseConection");
        services.AddDbContext<DentalManagerDBContext>(e => e.UseSqlServer(connection));

        services
            .AddScoped<IAppointmentRepository, AppointmentRepository>()
            .AddScoped<IAppointmentPaymentRepository, AppointmentPaymentRepository>()
            .AddScoped<IAppointmentServiceRepository, AppointmentServiceRepository>()
            .AddScoped<IAppointmentStatusRepository, AppointmentStatusRepository>()
            .AddScoped<ICityRepository, CityRepository>()
            .AddScoped<IDayRepository, DayRepository>()
            .AddScoped<IOfficeRepository, OfficeRepository>()
            .AddScoped<IPatientRepository, PatientRepository>()
            .AddScoped<IPositionRepository, PositionRepository>()
            .AddScoped<ISalaryPaymentRepository, SalaryPaymentRepository>()
            .AddScoped<IScheduleRepository, ScheduleRepository>()
            .AddScoped<ITimeSegmentRepository, TimeSegmentRepository>()
            .AddScoped<IServiceRepository, ServiceRepository>()
            .AddScoped<IServiceTypeRepository, ServiceTypeRepository>()
            .AddScoped<IWorkerRepository, WorkerRepository>()
            .AddScoped<IWorkerScheduleRepository, WorkerScheduleRepository>();

        return services;
    }
}
