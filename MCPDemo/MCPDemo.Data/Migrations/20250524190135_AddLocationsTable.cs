using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCPDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubRegion1Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubRegion2Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsoCountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationKey);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
