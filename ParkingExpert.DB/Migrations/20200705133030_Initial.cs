using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingExpert.DB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(nullable: true),
                    PayedAt = table.Column<DateTime>(nullable: true),
                    ArrivedAt = table.Column<DateTime>(nullable: false),
                    DepartureAt = table.Column<DateTime>(nullable: true),
                    PayedAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerHour = table.Column<decimal>(nullable: false),
                    ParkingCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "ParkingCapacity", "PricePerHour" },
                values: new object[] { 1, 50, 10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingPlaces");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
