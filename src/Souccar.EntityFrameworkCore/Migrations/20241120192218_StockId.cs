using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class StockId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Sizes_SizeId",
                table: "StockHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Units_UnitId",
                table: "StockHistories");

            migrationBuilder.DropIndex(
                name: "IX_StockHistories_SizeId",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "StockHistories");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "StockHistories",
                newName: "StockId");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_UnitId",
                table: "StockHistories",
                newName: "IX_StockHistories_StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Stocks_StockId",
                table: "StockHistories",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Stocks_StockId",
                table: "StockHistories");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "StockHistories",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_StockId",
                table: "StockHistories",
                newName: "IX_StockHistories_UnitId");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "StockHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_SizeId",
                table: "StockHistories",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Sizes_SizeId",
                table: "StockHistories",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Units_UnitId",
                table: "StockHistories",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
