using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class onetomany_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppointmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppointmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AppointmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AppointmentId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPayments_AppointmentId",
                table: "AppointmentPayments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPayments_Appointments_AppointmentId",
                table: "AppointmentPayments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPayments_Appointments_AppointmentId",
                table: "AppointmentPayments");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentPayments_AppointmentId",
                table: "AppointmentPayments");

            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppointmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppointmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AppointmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AppointmentPayments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AppointmentId",
                value: 5);
        }
    }
}
