using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Relations_To_Stock_History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_SizeId",
                table: "StockHistories",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_UnitId",
                table: "StockHistories",
                column: "UnitId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_StockHistories_UnitId",
                table: "StockHistories");
        }
    }
}
