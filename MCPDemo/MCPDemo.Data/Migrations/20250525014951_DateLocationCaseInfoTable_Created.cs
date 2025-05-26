using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCPDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class DateLocationCaseInfoTable_Created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateLocationCaseInfo",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NewConfirmedCases = table.Column<int>(type: "int", nullable: true),
                    NewDeceasedCases = table.Column<int>(type: "int", nullable: true),
                    NewRecoveredCases = table.Column<int>(type: "int", nullable: true),
                    NewTestsConducted = table.Column<int>(type: "int", nullable: true),
                    CumulativeConfirmedCases = table.Column<int>(type: "int", nullable: true),
                    CumulativeDeceasedCases = table.Column<int>(type: "int", nullable: true),
                    CumulativeRecoveredCases = table.Column<int>(type: "int", nullable: true),
                    CumulativeTestsConducted = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateLocationCaseInfo", x => new { x.Date, x.LocationKey });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateLocationCaseInfo");
        }
    }
}
