using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Unit_To_Material : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Units_UnitId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_UnitId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_UnitId",
                table: "Materials",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Units_UnitId",
                table: "Materials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Units_UnitId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_UnitId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Stocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UnitId",
                table: "Stocks",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Units_UnitId",
                table: "Stocks",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
