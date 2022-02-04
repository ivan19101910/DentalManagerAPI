using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class moreseederdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Консультація" },
                    { 2, "Діагностика" },
                    { 3, "Анестезія" },
                    { 4, "Терапевтична та ендодонтична стоматологія" },
                    { 5, "Дитяча стоматологія" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name", "Price", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, "Dolor sit amet", "Консультація лікаря – стоматолога", 100m, 1 },
                    { 2, "Lorem", "Консультація кандидата медичних наук, доцента", 200m, 1 },
                    { 3, "Ipsum", "Консультація лікаря-імплантолога, ортопеда, ортодонта, пародонтолога", 300m, 1 },
                    { 4, "El lingua", "Повторний видрук ортопантомограми", 400m, 5 },
                    { 5, "Moloc boloc", "Комп’ютерна томографія 1 щелепи", 500m, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
