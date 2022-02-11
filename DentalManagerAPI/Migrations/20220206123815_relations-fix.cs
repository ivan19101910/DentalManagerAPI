using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class relationsfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "AppointmentPercentage", "BaseRate", "PositionName" },
                values: new object[] { 1, 75m, 0m, "Парадонтолог" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "AppointmentPercentage", "BaseRate", "PositionName" },
                values: new object[] { 2, 1m, 10000m, "Менеджер" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "AppointmentPercentage", "BaseRate", "PositionName" },
                values: new object[] { 3, 0m, 5000m, "Прибиральниця" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OfficeId", "PositionId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_OfficeId",
                table: "Workers",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PositionId",
                table: "Workers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Offices_OfficeId",
                table: "Workers",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Positions_PositionId",
                table: "Workers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Offices_OfficeId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Positions_PositionId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_OfficeId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_PositionId",
                table: "Workers");

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OfficeId", "PositionId" },
                values: new object[] { null, null });
        }
    }
}
