using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "TransportCompanyCashFlow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DamagedNumberInLargeUnit",
                table: "Stock",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DamagedNumberInSmallUnit",
                table: "Stock",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "CustomerCashFlow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "ClearanceCompanyCashFlow",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "TransportCompanyCashFlow");

            migrationBuilder.DropColumn(
                name: "DamagedNumberInLargeUnit",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "DamagedNumberInSmallUnit",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "CustomerCashFlow");

            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "ClearanceCompanyCashFlow");
        }
    }
}
