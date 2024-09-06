using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Supplier_Item_Level : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receiving_Customer_SupplierId",
                table: "Receiving");

            migrationBuilder.DropIndex(
                name: "IX_Receiving_SupplierId",
                table: "Receiving");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Receiving");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "ReceivingItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingItem_SupplierId",
                table: "ReceivingItem",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SupplierId",
                table: "Invoice",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Customer_SupplierId",
                table: "Invoice",
                column: "SupplierId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingItem_Customer_SupplierId",
                table: "ReceivingItem",
                column: "SupplierId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Customer_SupplierId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingItem_Customer_SupplierId",
                table: "ReceivingItem");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingItem_SupplierId",
                table: "ReceivingItem");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_SupplierId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ReceivingItem");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Receiving",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_SupplierId",
                table: "Receiving",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receiving_Customer_SupplierId",
                table: "Receiving",
                column: "SupplierId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
