using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class seeder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 3, "test3", new DateTime(2002, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maksym", "Boiko", "+380963386182" });
        }
    }
}
