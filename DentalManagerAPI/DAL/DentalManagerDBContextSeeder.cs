using DentalManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalManagerAPI.DAL
{
    public class DentalManagerDBContextSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasData(new Patient() { Id = 1, Address = "test", DateOfBirth = new DateTime(2000, 10, 19).Date, FirstName = "Ivan", LastName = "Raikovskyi", PhoneNumber = "+380673646192" },
                new Patient() { Id = 2, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 3, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 4, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 5, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 6, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 7, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 8, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 9, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 10, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 11, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 12, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 13, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 14, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 15, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 16, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 17, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 18, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 19, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 20, Address = "test2", DateOfBirth = new DateTime(2001, 11, 19).Date, FirstName = "Mykola", LastName = "Harch", PhoneNumber = "+380973656192" },
                new Patient() { Id = 21, Address = "test3", DateOfBirth = new DateTime(2002, 12, 19).Date, FirstName = "Maksym", LastName = "Boiko", PhoneNumber = "+380963386182" });

            modelBuilder.Entity<Worker>()
                .HasData(new Worker() { Id = 1, FirstName = "Ivan", LastName = "Raikovskyi", PhoneNumber = "+384613646192", Address="testadd", Email="test@gmail.com", Password ="test" });

            modelBuilder.Entity<ServiceType>()
                .HasData(new ServiceType() { Id = 1, Name = "Консультація" },
                new ServiceType() { Id = 2, Name = "Діагностика" },
                new ServiceType() { Id = 3, Name = "Анестезія" },
                new ServiceType() { Id = 4, Name = "Терапевтична та ендодонтична стоматологія" },
                new ServiceType() { Id = 5, Name = "Дитяча стоматологія" });

            modelBuilder.Entity<Service>()
                .HasData(new Service() { Id = 1, Name = "Консультація лікаря – стоматолога", Price = 100, Description = "Dolor sit amet", ServiceTypeId = 1 },
                new Service() { Id = 2, Name = "Консультація кандидата медичних наук, доцента", Price = 200, Description = "Lorem", ServiceTypeId = 1 },
                new Service() { Id = 3, Name = "Консультація лікаря-імплантолога, ортопеда, ортодонта, пародонтолога", Price = 300, Description = "Ipsum", ServiceTypeId = 1 },
                new Service() { Id = 4, Name = "Повторний видрук ортопантомограми", Price = 400, Description = "El lingua", ServiceTypeId = 5 },
                new Service() { Id = 5, Name = "Комп’ютерна томографія 1 щелепи", Price = 500, Description = "Moloc boloc", ServiceTypeId = 5 });

            modelBuilder.Entity<City>()
                .HasData(new City() { Id = 1, Name = "Славута" },
                new City() { Id = 2, Name = "Львів" },
                new City() { Id = 3, Name = "Київ" },
                new City() { Id = 4, Name = "Івано-Франківськ" });

            modelBuilder.Entity<Office>()
                .HasData(new Office() { Id = 1, Address = "Б.Хмельницого 45", CityId = 1 },
                new Office() { Id = 2, Address = "C.Бандери 11а", CityId = 2 },
                new Office() { Id = 3, Address = "Б.Хмельницого 155", CityId = 3 },
                new Office() { Id = 4, Address = "І.Франка 123", CityId = 4 },
                new Office() { Id = 5, Address = "Стрийська 198а", CityId = 2 });

            modelBuilder.Entity<AppointmentStatus>()
                .HasData(new AppointmentStatus() { Id = 1, Name = "Новий" },
                new AppointmentStatus() { Id = 2, Name = "Завершений" },
                new AppointmentStatus() { Id = 3, Name = "Оплачений" });

            modelBuilder.Entity<AppointmentPayment>()
                .HasData(new AppointmentPayment { Id = 1, AppointmentId = 1, Total = 500, TransactionNumber = 1 },
                new AppointmentPayment { Id = 2, AppointmentId = 1, Total = 500, TransactionNumber = 2 },
                new AppointmentPayment { Id = 3, AppointmentId = 1, Total = 500, TransactionNumber = 3 },
                new AppointmentPayment { Id = 4, AppointmentId = 1, Total = 500, TransactionNumber = 4 },
                new AppointmentPayment { Id = 5, AppointmentId = 1, Total = 500, TransactionNumber = 5 });

            modelBuilder.Entity<Appointment>()
                .HasData(new Appointment() { Id = 1, AppointmentDate = new DateTime(2000, 10, 10), AppointmentTime = new TimeSpan(19, 10, 0), Notes = "Lorem",
                    PatientId = 1, RealEndTime = new TimeSpan(20, 0, 0), StatusId = 1, TotalSum = 500, WorkerId = 1 });

            modelBuilder.Entity<AppointmentService>()
                .HasData(new AppointmentService() { Id = 1, Amount = 5, AppointmentId = 1, ServiceId = 1 });
        }
    }
}
