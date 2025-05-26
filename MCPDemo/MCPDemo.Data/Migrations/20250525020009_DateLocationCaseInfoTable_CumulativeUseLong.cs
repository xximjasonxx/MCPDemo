using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCPDemo.Data.Migrations
{
    /// <inheritdoc />
    public partial class DateLocationCaseInfoTable_CumulativeUseLong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CumulativeTestsConducted",
                table: "DateLocationCaseInfo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CumulativeRecoveredCases",
                table: "DateLocationCaseInfo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CumulativeDeceasedCases",
                table: "DateLocationCaseInfo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CumulativeConfirmedCases",
                table: "DateLocationCaseInfo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CumulativeTestsConducted",
                table: "DateLocationCaseInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CumulativeRecoveredCases",
                table: "DateLocationCaseInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CumulativeDeceasedCases",
                table: "DateLocationCaseInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CumulativeConfirmedCases",
                table: "DateLocationCaseInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
