using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class moreseederdata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SalaryPayments",
                columns: new[] { "Id", "Amount", "MonthNumber", "TransactionNumber", "WorkerId", "Year" },
                values: new object[,]
                {
                    { 1, 1000m, (short)1, 1, 1, (short)2000 },
                    { 2, 1001m, (short)5, 2, 1, (short)2021 },
                    { 3, 1002m, (short)8, 3, 1, (short)2012 },
                    { 4, 1003m, (short)9, 4, 1, (short)2021 },
                    { 5, 1004m, (short)12, 5, 1, (short)2021 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SalaryPayments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
