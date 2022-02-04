using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalManagerAPI.Migrations
{
    public partial class office_and_city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Славута" },
                    { 2, "Львів" },
                    { 3, "Київ" },
                    { 4, "Івано-Франківськ" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Address", "CityId" },
                values: new object[,]
                {
                    { 1, "Б.Хмельницого 45", 1 },
                    { 2, "C.Бандери 11а", 2 },
                    { 3, "Б.Хмельницого 155", 3 },
                    { 4, "І.Франка 123", 4 },
                    { 5, "Стрийська 198а", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CityId",
                table: "Offices",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
