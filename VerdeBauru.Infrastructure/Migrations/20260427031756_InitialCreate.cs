using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerdeBauru.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirQualityRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Temperature = table.Column<decimal>(type: "numeric", nullable: false),
                    Humidity = table.Column<decimal>(type: "numeric", nullable: false),
                    IsFireAlert = table.Column<bool>(type: "boolean", nullable: false),
                    RecordAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirQualityRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirQualityRecords");
        }
    }
}
