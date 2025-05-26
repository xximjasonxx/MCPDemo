using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCPDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class LocationsTable_RemoveIsoCountryCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsoCountryCode",
                table: "Locations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsoCountryCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
