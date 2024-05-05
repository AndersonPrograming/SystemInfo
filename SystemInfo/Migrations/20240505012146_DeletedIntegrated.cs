using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemInfo.Migrations
{
    /// <inheritdoc />
    public partial class DeletedIntegrated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Scores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "FarmTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Farms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Farmers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "EnergyMeters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "EnergyLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "DeviceTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ContactTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "FarmTypes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Farms");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "EnergyMeters");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "EnergyLogs");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "DeviceTypes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ContactTypes");
        }
    }
}
