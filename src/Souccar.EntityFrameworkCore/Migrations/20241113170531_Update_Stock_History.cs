using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Stock_History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Stocks_StockId",
                table: "StockHistories");

            migrationBuilder.DropIndex(
                name: "IX_StockHistories_StockId",
                table: "StockHistories");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "StockHistories",
                newName: "UnitId");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "StockHistories",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "StockHistories");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "StockHistories",
                newName: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_StockId",
                table: "StockHistories",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Stocks_StockId",
                table: "StockHistories",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }
    }
}
