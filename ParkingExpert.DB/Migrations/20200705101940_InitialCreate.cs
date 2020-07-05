using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingExpert.DB.Migrations
{
    public partial class InitialCreate : Migration
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
                    Payed = table.Column<bool>(nullable: false),
                    ArrivedAt = table.Column<DateTime>(nullable: true),
                    DepartureAt = table.Column<DateTime>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false)
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
                    PricePerHour = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkingPlaces",
                columns: new[] { "Id", "ArrivedAt", "CarPlate", "DepartureAt", "IsAvailable", "Payed" },
                values: new object[,]
                {
                    { 1, null, null, null, true, false },
                    { 2, null, null, null, true, false },
                    { 3, null, null, null, true, false },
                    { 4, null, null, null, true, false },
                    { 5, null, null, null, true, false },
                    { 6, null, null, null, true, false },
                    { 7, null, null, null, true, false },
                    { 8, null, null, null, true, false },
                    { 9, null, null, null, true, false },
                    { 10, null, null, null, true, false }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "PricePerHour" },
                values: new object[] { 1, 10m });
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
