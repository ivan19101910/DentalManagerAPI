﻿// <auto-generated />
using System;
using DentalManagerAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    [DbContext(typeof(DentalManagerDBContext))]
    partial class DentalManagerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Ukrainian_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DentalManagerAPI.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("AppointmentTime")
                        .HasColumnType("time");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("RealEndTime")
                        .HasColumnType("time");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("StatusId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentDate = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AppointmentTime = new TimeSpan(0, 19, 10, 0, 0),
                            Notes = "Lorem",
                            PatientId = 1,
                            RealEndTime = new TimeSpan(0, 20, 0, 0, 0),
                            StatusId = 1,
                            TotalSum = 500m,
                            WorkerId = 1
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.AppointmentPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TransactionNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentPayments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            Total = 500m,
                            TransactionNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            Total = 500m,
                            TransactionNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 1,
                            Total = 500m,
                            TransactionNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 1,
                            Total = 500m,
                            TransactionNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            AppointmentId = 1,
                            Total = 500m,
                            TransactionNumber = 5
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 5,
                            AppointmentId = 1,
                            ServiceId = 1
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.AppointmentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppointmentStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Новий"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Завершений"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Оплачений"
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Славута"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Львів"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Київ"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Івано-Франківськ"
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Б.Хмельницого 45",
                            CityId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "C.Бандери 11а",
                            CityId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "Б.Хмельницого 155",
                            CityId = 3
                        },
                        new
                        {
                            Id = 4,
                            Address = "І.Франка 123",
                            CityId = 4
                        },
                        new
                        {
                            Id = 5,
                            Address = "Стрийська 198а",
                            CityId = 2
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "test",
                            DateOfBirth = new DateTime(2000, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ivan",
                            LastName = "Raikovskyi",
                            PhoneNumber = "+380673646192"
                        },
                        new
                        {
                            Id = 2,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 3,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 4,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 5,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 6,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 7,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 8,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 9,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 10,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 11,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 12,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 13,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 14,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 15,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 16,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 17,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 18,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 19,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 20,
                            Address = "test2",
                            DateOfBirth = new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mykola",
                            LastName = "Harch",
                            PhoneNumber = "+380973656192"
                        },
                        new
                        {
                            Id = 21,
                            Address = "test3",
                            DateOfBirth = new DateTime(2002, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Maksym",
                            LastName = "Boiko",
                            PhoneNumber = "+380963386182"
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Dolor sit amet",
                            Name = "Консультація лікаря – стоматолога",
                            Price = 100m,
                            ServiceTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem",
                            Name = "Консультація кандидата медичних наук, доцента",
                            Price = 200m,
                            ServiceTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Ipsum",
                            Name = "Консультація лікаря-імплантолога, ортопеда, ортодонта, пародонтолога",
                            Price = 300m,
                            ServiceTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "El lingua",
                            Name = "Повторний видрук ортопантомограми",
                            Price = 400m,
                            ServiceTypeId = 5
                        },
                        new
                        {
                            Id = 5,
                            Description = "Moloc boloc",
                            Name = "Комп’ютерна томографія 1 щелепи",
                            Price = 500m,
                            ServiceTypeId = 5
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Консультація"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Діагностика"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Анестезія"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Терапевтична та ендодонтична стоматологія"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Дитяча стоматологія"
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "testadd",
                            Email = "test@gmail.com",
                            FirstName = "Ivan",
                            LastName = "Raikovskyi",
                            Password = "test",
                            PhoneNumber = "+384613646192"
                        });
                });

            modelBuilder.Entity("DentalManagerAPI.Models.Appointment", b =>
                {
                    b.HasOne("DentalManagerAPI.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalManagerAPI.Models.AppointmentStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalManagerAPI.Models.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Status");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("DentalManagerAPI.Models.AppointmentPayment", b =>
                {
                    b.HasOne("DentalManagerAPI.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("DentalManagerAPI.Models.AppointmentService", b =>
                {
                    b.HasOne("DentalManagerAPI.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentalManagerAPI.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DentalManagerAPI.Models.Office", b =>
                {
                    b.HasOne("DentalManagerAPI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DentalManagerAPI.Models.Service", b =>
                {
                    b.HasOne("DentalManagerAPI.Models.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });
#pragma warning restore 612, 618
        }
    }
}
