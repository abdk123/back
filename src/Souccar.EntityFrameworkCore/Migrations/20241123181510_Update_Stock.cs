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
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "DamagedNumberInLargeUnit",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "NumberInSmallUnit",
                table: "Stocks",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "NumberInLargeUnit",
                table: "Stocks",
                newName: "DamagedQuantity");

            migrationBuilder.RenameColumn(
                name: "DamagedNumberInSmallUnit",
                table: "Stocks",
                newName: "ConversionValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stocks",
                newName: "NumberInSmallUnit");

            migrationBuilder.RenameColumn(
                name: "DamagedQuantity",
                table: "Stocks",
                newName: "NumberInLargeUnit");

            migrationBuilder.RenameColumn(
                name: "ConversionValue",
                table: "Stocks",
                newName: "DamagedNumberInSmallUnit");

            migrationBuilder.AddColumn<double>(
                name: "Count",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DamagedNumberInLargeUnit",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
