using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCPDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class DemographicsTable_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demographics",
                columns: table => new
                {
                    LocationKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPopulation = table.Column<int>(type: "int", nullable: false),
                    MalePopulation = table.Column<int>(type: "int", nullable: true),
                    FemalePopulation = table.Column<int>(type: "int", nullable: true),
                    RuralPopulation = table.Column<int>(type: "int", nullable: true),
                    UrbanPopulation = table.Column<int>(type: "int", nullable: true),
                    LargestCityPopulation = table.Column<int>(type: "int", nullable: true),
                    ClusteredPopulation = table.Column<int>(type: "int", nullable: true),
                    PopulationPerSquareKilometer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HumanDevelopmentIndex = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Population0To09 = table.Column<int>(type: "int", nullable: true),
                    Population10To19 = table.Column<int>(type: "int", nullable: true),
                    Population20To29 = table.Column<int>(type: "int", nullable: true),
                    Population30To39 = table.Column<int>(type: "int", nullable: true),
                    Population40To49 = table.Column<int>(type: "int", nullable: true),
                    Population50To59 = table.Column<int>(type: "int", nullable: true),
                    Population60To69 = table.Column<int>(type: "int", nullable: true),
                    Population70To79 = table.Column<int>(type: "int", nullable: true),
                    Population80Plus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.LocationKey);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demographics");
        }
    }
}
