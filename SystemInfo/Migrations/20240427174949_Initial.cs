using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemInfo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactTypes",
                columns: table => new
                {
                    ContactTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeContact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactTypes", x => x.ContactTypeId);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenerationCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceType = table.Column<int>(type: "int", nullable: false),
                    Farm = table.Column<int>(type: "int", nullable: false),
                    EnergyMeter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "deviceTypes",
                columns: table => new
                {
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDevice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deviceTypes", x => x.DeviceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "energyLogs",
                columns: table => new
                {
                    EnergyLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneratedEnergyKWH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumedEnergyKWH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergyMeter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_energyLogs", x => x.EnergyLogId);
                });

            migrationBuilder.CreateTable(
                name: "energyMeters",
                columns: table => new
                {
                    EnergyMeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnergyMeterBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_energyMeters", x => x.EnergyMeterId);
                });

            migrationBuilder.CreateTable(
                name: "farmers",
                columns: table => new
                {
                    FarmerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmers", x => x.FarmerId);
                });

            migrationBuilder.CreateTable(
                name: "farms",
                columns: table => new
                {
                    FarmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmType = table.Column<int>(type: "int", nullable: false),
                    Farmer = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farms", x => x.FarmId);
                });

            migrationBuilder.CreateTable(
                name: "farmTypes",
                columns: table => new
                {
                    FarmTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeFarm = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmTypes", x => x.FarmTypeId);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scores", x => x.ScoreId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Game = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactTypes");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "deviceTypes");

            migrationBuilder.DropTable(
                name: "energyLogs");

            migrationBuilder.DropTable(
                name: "energyMeters");

            migrationBuilder.DropTable(
                name: "farmers");

            migrationBuilder.DropTable(
                name: "farms");

            migrationBuilder.DropTable(
                name: "farmTypes");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "scores");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
