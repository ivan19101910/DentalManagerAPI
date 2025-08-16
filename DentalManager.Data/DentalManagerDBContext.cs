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

namespace DentalManager.Data;

public partial class DentalManagerDBContext : DbContext
{
    public DentalManagerDBContext()
    {

    }

    public DentalManagerDBContext(DbContextOptions<DentalManagerDBContext> options)
        : base(options)
    { 
        
    } 
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Worker> Workers { get; set; }
    public virtual DbSet<ServiceType> ServiceTypes { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Office> Offices { get; set; }
    public virtual DbSet<AppointmentPayment> AppointmentPayments { get; set; }
    public virtual DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
    public virtual DbSet<AppointmentService> AppointmentServices { get; set; }
    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }
    public virtual DbSet<Day> Days { get; set; }
    public virtual DbSet<TimeSegment> TimeSegments { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }
    public virtual DbSet<WorkerSchedule> WorkerSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

        DentalManagerDBContextSeeder.Seed(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
