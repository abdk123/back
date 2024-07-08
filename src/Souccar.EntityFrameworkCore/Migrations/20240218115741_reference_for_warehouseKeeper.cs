using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class reference_for_warehouseKeeper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarehouseKeeper",
                table: "Warehouses");

            migrationBuilder.AddColumn<long>(
                name: "WarehouseKeeperId",
                table: "Warehouses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_WarehouseKeeperId",
                table: "Warehouses",
                column: "WarehouseKeeperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AbpUsers_WarehouseKeeperId",
                table: "Warehouses",
                column: "WarehouseKeeperId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AbpUsers_WarehouseKeeperId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_WarehouseKeeperId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "WarehouseKeeperId",
                table: "Warehouses");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseKeeper",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
