using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaderboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    RaceStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    VehicleSubType = table.Column<int>(type: "int", nullable: false),
                    ManufacturingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    RepairmentTime = table.Column<int>(type: "int", nullable: false),
                    LightMalfunctionChance = table.Column<double>(type: "float", nullable: false),
                    LightMalfunctionsTimesOccured = table.Column<int>(type: "int", nullable: false),
                    HeavyMalfunctionChance = table.Column<double>(type: "float", nullable: false),
                    HeavyMalfunctionOccured = table.Column<bool>(type: "bit", nullable: false),
                    FinishedRaceInHours = table.Column<int>(type: "int", nullable: false),
                    DistanceCoverdInKm = table.Column<int>(type: "int", nullable: false),
                    LeaderboardEntityId = table.Column<int>(type: "int", nullable: true),
                    RaceEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Leaderboards_LeaderboardEntityId",
                        column: x => x.LeaderboardEntityId,
                        principalTable: "Leaderboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Races_RaceEntityId",
                        column: x => x.RaceEntityId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LeaderboardEntityId",
                table: "Vehicles",
                column: "LeaderboardEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RaceEntityId",
                table: "Vehicles",
                column: "RaceEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Leaderboards");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
