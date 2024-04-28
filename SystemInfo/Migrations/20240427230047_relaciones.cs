using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemInfo.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_scores",
                table: "scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_games",
                table: "games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_farmTypes",
                table: "farmTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_farms",
                table: "farms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_farmers",
                table: "farmers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_energyMeters",
                table: "energyMeters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_energyLogs",
                table: "energyLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deviceTypes",
                table: "deviceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_devices",
                table: "devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contactTypes",
                table: "contactTypes");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "scores",
                newName: "Scores");

            migrationBuilder.RenameTable(
                name: "games",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "farmTypes",
                newName: "FarmTypes");

            migrationBuilder.RenameTable(
                name: "farms",
                newName: "Farms");

            migrationBuilder.RenameTable(
                name: "farmers",
                newName: "Farmers");

            migrationBuilder.RenameTable(
                name: "energyMeters",
                newName: "EnergyMeters");

            migrationBuilder.RenameTable(
                name: "energyLogs",
                newName: "EnergyLogs");

            migrationBuilder.RenameTable(
                name: "deviceTypes",
                newName: "DeviceTypes");

            migrationBuilder.RenameTable(
                name: "devices",
                newName: "Devices");

            migrationBuilder.RenameTable(
                name: "contactTypes",
                newName: "ContactTypes");

            migrationBuilder.RenameColumn(
                name: "Game",
                table: "Users",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Games",
                newName: "ScoreId");

            migrationBuilder.RenameColumn(
                name: "Farmer",
                table: "Farms",
                newName: "FarmerId");

            migrationBuilder.RenameColumn(
                name: "FarmType",
                table: "Farms",
                newName: "FarmTypeId");

            migrationBuilder.RenameColumn(
                name: "ContactType",
                table: "Farmers",
                newName: "ContactTypeId");

            migrationBuilder.RenameColumn(
                name: "EnergyMeter",
                table: "EnergyLogs",
                newName: "EnergyMeterId");

            migrationBuilder.RenameColumn(
                name: "Farm",
                table: "Devices",
                newName: "FarmId");

            migrationBuilder.RenameColumn(
                name: "EnergyMeter",
                table: "Devices",
                newName: "EnergyMeterId");

            migrationBuilder.RenameColumn(
                name: "DeviceType",
                table: "Devices",
                newName: "DeviceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "ScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FarmTypes",
                table: "FarmTypes",
                column: "FarmTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Farms",
                table: "Farms",
                column: "FarmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Farmers",
                table: "Farmers",
                column: "FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnergyMeters",
                table: "EnergyMeters",
                column: "EnergyMeterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnergyLogs",
                table: "EnergyLogs",
                column: "EnergyLogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes",
                column: "DeviceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactTypes",
                table: "ContactTypes",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GameId",
                table: "Users",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ScoreId",
                table: "Games",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmTypeId",
                table: "Farms",
                column: "FarmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_ContactTypeId",
                table: "Farmers",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLogs_EnergyMeterId",
                table: "EnergyLogs",
                column: "EnergyMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_EnergyMeterId",
                table: "Devices",
                column: "EnergyMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FarmId",
                table: "Devices",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceTypes_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "DeviceTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_EnergyMeters_EnergyMeterId",
                table: "Devices",
                column: "EnergyMeterId",
                principalTable: "EnergyMeters",
                principalColumn: "EnergyMeterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Farms_FarmId",
                table: "Devices",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyLogs_EnergyMeters_EnergyMeterId",
                table: "EnergyLogs",
                column: "EnergyMeterId",
                principalTable: "EnergyMeters",
                principalColumn: "EnergyMeterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_ContactTypes_ContactTypeId",
                table: "Farmers",
                column: "ContactTypeId",
                principalTable: "ContactTypes",
                principalColumn: "ContactTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_FarmTypes_FarmTypeId",
                table: "Farms",
                column: "FarmTypeId",
                principalTable: "FarmTypes",
                principalColumn: "FarmTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "ScoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Games_GameId",
                table: "Users",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceTypes_DeviceTypeId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_EnergyMeters_EnergyMeterId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Farms_FarmId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_EnergyLogs_EnergyMeters_EnergyMeterId",
                table: "EnergyLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_ContactTypes_ContactTypeId",
                table: "Farmers");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_FarmTypes_FarmTypeId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_Farmers_FarmerId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Scores_ScoreId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Games_GameId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GameId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ScoreId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FarmTypes",
                table: "FarmTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Farms",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmTypeId",
                table: "Farms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Farmers",
                table: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_ContactTypeId",
                table: "Farmers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnergyMeters",
                table: "EnergyMeters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnergyLogs",
                table: "EnergyLogs");

            migrationBuilder.DropIndex(
                name: "IX_EnergyLogs_EnergyMeterId",
                table: "EnergyLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_EnergyMeterId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_FarmId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactTypes",
                table: "ContactTypes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "scores");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "games");

            migrationBuilder.RenameTable(
                name: "FarmTypes",
                newName: "farmTypes");

            migrationBuilder.RenameTable(
                name: "Farms",
                newName: "farms");

            migrationBuilder.RenameTable(
                name: "Farmers",
                newName: "farmers");

            migrationBuilder.RenameTable(
                name: "EnergyMeters",
                newName: "energyMeters");

            migrationBuilder.RenameTable(
                name: "EnergyLogs",
                newName: "energyLogs");

            migrationBuilder.RenameTable(
                name: "DeviceTypes",
                newName: "deviceTypes");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "devices");

            migrationBuilder.RenameTable(
                name: "ContactTypes",
                newName: "contactTypes");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "users",
                newName: "Game");

            migrationBuilder.RenameColumn(
                name: "ScoreId",
                table: "games",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "FarmerId",
                table: "farms",
                newName: "Farmer");

            migrationBuilder.RenameColumn(
                name: "FarmTypeId",
                table: "farms",
                newName: "FarmType");

            migrationBuilder.RenameColumn(
                name: "ContactTypeId",
                table: "farmers",
                newName: "ContactType");

            migrationBuilder.RenameColumn(
                name: "EnergyMeterId",
                table: "energyLogs",
                newName: "EnergyMeter");

            migrationBuilder.RenameColumn(
                name: "FarmId",
                table: "devices",
                newName: "Farm");

            migrationBuilder.RenameColumn(
                name: "EnergyMeterId",
                table: "devices",
                newName: "EnergyMeter");

            migrationBuilder.RenameColumn(
                name: "DeviceTypeId",
                table: "devices",
                newName: "DeviceType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_scores",
                table: "scores",
                column: "ScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_games",
                table: "games",
                column: "GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_farmTypes",
                table: "farmTypes",
                column: "FarmTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_farms",
                table: "farms",
                column: "FarmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_farmers",
                table: "farmers",
                column: "FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_energyMeters",
                table: "energyMeters",
                column: "EnergyMeterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_energyLogs",
                table: "energyLogs",
                column: "EnergyLogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deviceTypes",
                table: "deviceTypes",
                column: "DeviceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_devices",
                table: "devices",
                column: "DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contactTypes",
                table: "contactTypes",
                column: "ContactTypeId");
        }
    }
}
