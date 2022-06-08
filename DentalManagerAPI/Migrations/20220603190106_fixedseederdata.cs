using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class fixedseederdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Workers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Patient",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Миколая 67", "Микола", "Харш", "0673646191" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Є. Коновальця 31а", new DateTime(2001, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Йосип", "Горняткевич", "0973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Пулюя 24", new DateTime(2001, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лев", "Марунчак", "0973656193" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Наукова 44", new DateTime(2001, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Йоган", "Іващук", "0973656194" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Стрийська 192", new DateTime(2001, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Костянтин", "Андрухович", "0973656195" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Кн. Ольги 12", new DateTime(2001, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Марко", "Клименко", "0973656196" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "С. Крушельницької 13", new DateTime(2001, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Федір", "Губ'як", "0973656197" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Сміливих 27", new DateTime(2001, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Юрій", "Скрипник", "0973656198" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Б.Хмельницкого 155", new DateTime(2001, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миролюб", "Кротевич", "0973656199" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Кульпарківська 1", new DateTime(2001, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Євген", "Островський", "0973656119" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Садова 11", new DateTime(2001, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Євген", "Чеховський", "0973656112" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Любінська 89", new DateTime(2001, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Федір", "Кубів", "0973096192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Антоновича 67", new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Нестор", "Дехтяренко", "0913656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "Героїв УПА 44", new DateTime(2001, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ілля", "Герасимюк", "0973678192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "С. Бандери 22", new DateTime(2001, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Маркіян", "Ковтун", "0973506192" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "І.Пулюя 33а", "Іван", "Райковський", "0613646191" });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "OfficeId", "Password", "PhoneNumber", "PositionId" },
                values: new object[,]
                {
                    { 2, "testadd", "test@gmail.com", "Ілля", "Чеховський", 1, "a98ec5c5044800c88e862f007b98d89815fc40ca155d6ce7909530d792e909ce", "0613646192", 1 },
                    { 3, "testadd", "test@gmail.com", "Максим", "Притула", 1, "a98ec5c5044800c88e862f007b98d89815fc40ca155d6ce7909530d792e909ce", "0613646193", 1 },
                    { 4, "testadd", "test@gmail.com", "Федір", "Бандера", 1, "a98ec5c5044800c88e862f007b98d89815fc40ca155d6ce7909530d792e909ce", "0613646194", 1 },
                    { 5, "testadd", "test@gmail.com", "Максим", "Мовчан", 1, "a98ec5c5044800c88e862f007b98d89815fc40ca155d6ce7909530d792e909ce", "0613646195", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PhoneNumber",
                table: "Workers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PhoneNumber",
                table: "Patient",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Workers_PhoneNumber",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Patient_PhoneNumber",
                table: "Patient");

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test", "Ivan", "Raikovskyi", "+380673646192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 16, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 17, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 18, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 19, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 20, "test2", new DateTime(2001, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykola", "Harch", "+380973656192" },
                    { 21, "test3", new DateTime(2002, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maksym", "Boiko", "+380963386182" }
                });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "testadd", "Ivan", "Raikovskyi", "+384613646192" });
        }
    }
}
