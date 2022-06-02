﻿using DentalManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
                .HasData(new Worker() { Id = 1, FirstName = "Ivan", LastName = "Raikovskyi", PhoneNumber = "+384613646192", Address="testadd", Email="test@gmail.com", Password = "a98ec5c5044800c88e862f007b98d89815fc40ca155d6ce7909530d792e909ce", OfficeId = 1, PositionId = 1  });

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

            modelBuilder.Entity<Position>()
                .HasData(new Position() { Id = 1, AppointmentPercentage = 75, BaseRate = 0, PositionName = "Парадонтолог" },
                new Position() { Id = 2, AppointmentPercentage = 1, BaseRate = 10000, PositionName = "Менеджер" },
                new Position() { Id = 3, AppointmentPercentage = 0, BaseRate = 5000, PositionName = "Прибиральниця" });

            modelBuilder.Entity<Day>()
                .HasData(new Day() { Id = 1, Name = "Понеділок" },
                new Day() { Id = 2, Name = "Вівторок" },
                new Day() { Id = 3, Name = "Середа" },
                new Day() { Id = 4, Name = "Четвер" },
                new Day() { Id = 5, Name = "П'ятниця" },
                new Day() { Id = 6, Name = "Субота" },
                new Day() { Id = 7, Name = "Неділя" });

            modelBuilder.Entity<TimeSegment>()
                .HasData(new TimeSegment() { Id = 1, TimeStart = new TimeSpan(10, 0, 0), TimeEnd = new TimeSpan(18, 0, 0) },
                new TimeSegment() { Id = 2, TimeStart = new TimeSpan(8, 0, 0), TimeEnd = new TimeSpan(20, 0, 0) },
                new TimeSegment() { Id = 3, TimeStart = new TimeSpan(12, 0, 0), TimeEnd = new TimeSpan(22, 0, 0) },
                new TimeSegment() { Id = 4, TimeStart = new TimeSpan(16, 0, 0), TimeEnd = new TimeSpan(22, 0, 0) },
                new TimeSegment() { Id = 5, TimeStart = new TimeSpan(8, 0, 0), TimeEnd = new TimeSpan(16, 0, 0) });

            modelBuilder.Entity<Schedule>()
                .HasData(new Schedule() { Id = 1, DayId = 1, TimeSegmentId = 1 },
                new Schedule() { Id = 2, DayId = 2, TimeSegmentId = 2 },
                new Schedule() { Id = 3, DayId = 3, TimeSegmentId = 3 },
                new Schedule() { Id = 4, DayId = 4, TimeSegmentId = 3 },
                new Schedule() { Id = 5, DayId = 5, TimeSegmentId = 5 });

            modelBuilder.Entity<WorkerSchedule>()
                .HasData(new WorkerSchedule() { Id = 1, WorkerId = 1, ScheduleId = 1 },
                new WorkerSchedule() { Id = 2, WorkerId = 1, ScheduleId = 2 },
                new WorkerSchedule() { Id = 3, WorkerId = 1, ScheduleId = 3 },
                new WorkerSchedule() { Id = 4, WorkerId = 1, ScheduleId = 4 },
                new WorkerSchedule() { Id = 5, WorkerId = 1, ScheduleId = 5 });

            modelBuilder.Entity<SalaryPayment>()
                .HasData(new SalaryPayment() { Id = 1, WorkerId = 1, Amount = 1000, MonthNumber = 1, Year = 2000, TransactionNumber = 1 },
                new SalaryPayment() { Id = 2, WorkerId = 1, Amount = 1001, MonthNumber = 5, Year = 2021, TransactionNumber = 2 },
                new SalaryPayment() { Id = 3, WorkerId = 1, Amount = 1002, MonthNumber = 8, Year = 2012, TransactionNumber = 3 },
                new SalaryPayment() { Id = 4, WorkerId = 1, Amount = 1003, MonthNumber = 9, Year = 2021, TransactionNumber = 4 },
                new SalaryPayment() { Id = 5, WorkerId = 1, Amount = 1004, MonthNumber = 12, Year = 2021, TransactionNumber = 5 });
        }
    }
}
