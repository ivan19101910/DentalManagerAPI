﻿// <auto-generated />
using System;
using DentalManagerAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    [DbContext(typeof(DentalManagerDBContext))]
    [Migration("20220113212757_addworker")]
    partial class addworker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Ukrainian_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            Address = "test3",
                            DateOfBirth = new DateTime(2002, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Maksym",
                            LastName = "Boiko",
                            PhoneNumber = "+380963386182"
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
#pragma warning restore 612, 618
        }
    }
}
