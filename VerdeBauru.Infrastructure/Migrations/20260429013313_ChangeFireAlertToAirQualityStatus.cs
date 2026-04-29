using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerdeBauru.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFireAlertToAirQualityStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFireAlert",
                table: "AirQualityRecords");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AirQualityRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AirQualityRecords");

            migrationBuilder.AddColumn<bool>(
                name: "IsFireAlert",
                table: "AirQualityRecords",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
