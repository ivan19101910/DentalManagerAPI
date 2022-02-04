using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class seedernew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 3, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 4, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 5, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 6, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 7, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 8, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 9, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 10, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 11, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 12, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 13, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 14, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 15, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 16, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 17, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 18, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 19, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 20, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 21, "test3", new DateTime(2002, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maksym", "Boiko", "+380963386182" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
